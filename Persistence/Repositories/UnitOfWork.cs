using Application.DomainEvents;
using Persistence.Repositories.Identity;
using Persistence.Repositories.Lv;

namespace Persistence.Repositories
{
    public class UnitOfWork(
        ApplicationDbContext context,
        IEntityContext EntityContext,
        IDomainEventsDispatcher domainEventsDispatcher,
        IHttpContextAccessor httpContext) : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IEntityContext _entityContext = EntityContext ?? throw new ArgumentNullException(nameof(EntityContext));
        private readonly IDomainEventsDispatcher _domainEventsDispatcher = domainEventsDispatcher ?? throw new ArgumentNullException(nameof(domainEventsDispatcher));
        private readonly IHttpContextAccessor _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        private bool _disposed = false;

        #region Identity Repositories
        private IAddressRepository _addressRepository;
        private IRoleClaimsRepository _roleClaimsRepository;
        private IRolesRepository _rolesRepository;
        private IEntityAddressRepository _entityAddressRepository;
        private IEntityClaimRepository _entityClaimRepository;
        private IEntityContactRepository _entityContactRepository;
        private IEntityInformationRepository _entityInformationRepository;
        private IEntityLoginRepository _entityLoginRepository;
        private IEntityRepository _entityRepository;
        private IEntityRolesRepository _entityRolesRepository;
        private IEntityTokenRepository _entityTokenRepository;
        private IEntityVerificationsRepository _verificationCodesRepository;

        public IAddressRepository AddressRepository 
            => _addressRepository ??= new AddressRepository(_context);
        public IRoleClaimsRepository RoleClaimsRepository
            => _roleClaimsRepository ??= new RoleClaimRepository(_context);
        public IRolesRepository RolesRepository
            => _rolesRepository ??= new RolesRepository(_context);
        public IEntityAddressRepository EntityAddressRepository
            => _entityAddressRepository ??= new EntityAddressRepository(_context);
        public IEntityClaimRepository EntityClaimRepository
            => _entityClaimRepository ??= new EntityClaimRepository(_context);
        public IEntityContactRepository EntityContactRepository
            => _entityContactRepository ??= new EntityContactRepository(_context);
        public IEntityInformationRepository EntityInformationRepository
            => _entityInformationRepository ??= new EntityInformationRepository(_context);
        public IEntityLoginRepository EntityLoginRepository
            => _entityLoginRepository ??= new EntityLoginRepository(_context);
        public IEntityRepository EntityRepository
            => _entityRepository ??= new EntityRepository(_context);
        public IEntityRolesRepository EntityRolesRepository
            => _entityRolesRepository ??= new EntityRoleRepository(_context);
        public IEntityTokenRepository EntityTokenRepository
            => _entityTokenRepository ??= new EntityTokenRepository(_context);
        public IEntityVerificationsRepository VerificationCodesRepository
            => _verificationCodesRepository ??= new EntityVerificationsRepository(_context);
        #endregion

        #region Logging Repositories

        #endregion

        #region Lv Repositories
        private ILvAddressTypeRepository _lvAddressTypeRepository;
        private ILvContactTypeRepository _lvContactTypeRepository;
        private ILvVerificationCodeTypeRepository _lvVerificationCodeTypeRepository;

        public ILvAddressTypeRepository LvAddressTypeRepository
            => _lvAddressTypeRepository ??= new LvAddressTypeRepository(_context);
        public ILvContactTypeRepository LvContactTypeRepository
            => _lvContactTypeRepository ??= new LvContactTypeRepository(_context);
        public ILvVerificationCodeTypeRepository LvVerificationCodeTypeRepository
            => _lvVerificationCodeTypeRepository ??= new LvVerificationCodeTypeRepository(_context);

        #endregion

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            int result = 0;
            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                _context.ChangeTracker.DetectChanges();

                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    this.UpdateAuditableEntities();

                    // Track changes for audit logging before saving
                    var auditEntries = OnBeforeSaveChanges();

                    result = await _context.SaveChangesAsync();

                    // Save audit logs after successful save
                    await OnAfterSaveChanges(auditEntries);

                    //await LogApplicationEvent("Database changes saved successfully", LogLevelEnumStatus.Information);

                    await transaction.CommitAsync();

                    // TODO: Implement Domain event
                    await PublishDomainEventsAsync();
                }
                catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
                {
                    await transaction.RollbackAsync();

                    var metaDataNames = dbUpdateConcurrencyException.Entries
                        .Select(entry => entry.Metadata.Name)
                        .ToList();

                    var names = string.Join(", ", metaDataNames);

                    throw new DbUpdateConcurrencyException(
                        $"Concurrency Error: Data has been updated. Metadata: {names}",
                        dbUpdateConcurrencyException);
                }
                catch
                {
                    await transaction.RollbackAsync();

                    throw;
                }
                finally
                {
                    if (transaction != null) await transaction.DisposeAsync();
                }
            });

            return result;
        }

        private void UpdateAuditableEntities()
        {
            _ = Guid.TryParse(_entityContext.EntityId, out Guid currentEntityId);
            var currentTime = DateTime.UtcNow;

            foreach (var entry in _context.ChangeTracker.Entries<IBaseAudit>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = currentTime;
                    entry.Entity.CreatedById = currentEntityId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = currentTime;
                    entry.Entity.UpdatedById = currentEntityId;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.RemovedDate = currentTime;
                    entry.Entity.RemovedById = currentEntityId;
                    entry.Entity.IsActive = false;
                }
            }
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            _context.ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            var httpContext = _httpContext.HttpContext;

            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.Entity is AppLog || entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Entity.GetType().Name,
                    EntityId = _entityContext.EntityId ?? string.Empty,
                    Endpoint = httpContext.Request.Path.Value,
                    HttpMethod = httpContext.Request.Method
                };
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue ?? string.Empty;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = "Create";
                            auditEntry.NewValues[propertyName] = property.CurrentValue ?? string.Empty;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = "Delete";
                            auditEntry.OldValues[propertyName] = property.OriginalValue ?? string.Empty;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.AuditType = "Update";

                                var columnType = property.Metadata.GetColumnType();
                                bool isSameValue = false;

                                if (columnType.Contains("decimal"))
                                {
                                    var oldValue = property.OriginalValue != null ? (decimal?)property.OriginalValue : null;
                                    var newValue = property.CurrentValue != null ? (decimal?)property.CurrentValue : null;

                                    isSameValue = oldValue == newValue;
                                }
                                else if (columnType.Contains("date"))
                                {
                                    var oldValue = property.OriginalValue != null ? (DateTime?)property.OriginalValue : null;
                                    var newValue = property.CurrentValue != null ? (DateTime?)property.CurrentValue : null;

                                    isSameValue = oldValue == newValue;
                                }
                                else
                                {
                                    var oldValue = property.OriginalValue?.ToString();
                                    var newValue = property.CurrentValue?.ToString();

                                    isSameValue = oldValue == newValue;
                                }

                                if (!isSameValue)
                                {
                                    auditEntry.OldValues[propertyName] = property.OriginalValue;
                                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                                    auditEntry.ChangedColumns.Add(propertyName);
                                }
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ =>
                !_.HasTemporaryProperties && (_.OldValues.Count != 0 || _.NewValues.Count != 0)
            ))
            {
                _context.AuditLog.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }
        private async Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue ?? string.Empty;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue ?? string.Empty;
                    }
                }

                // Save the Audit entry
                _context.AuditLog.Add(auditEntry.ToAudit());
            }

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context?.Dispose();

                _disposed = true;
            }
        }

        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = _context.ChangeTracker
                .Entries<IEntity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    List<IDomainEvent> domainEvents = entity.DomainEvents;

                    entity.ClearDomainEvents();

                    return domainEvents;
                })
                .ToList();

            await domainEventsDispatcher.DispatchAsync(domainEvents);
        }
    }
}
