namespace Persistence.Configuration.Identity
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable(name: EntityConfigurationConstants.TableName);
            builder.HasKey(a => a.Id);

            // Indexes for "normalized" Entityname and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).IsUnique();
            builder.HasIndex(u => u.NormalizedEmail);

            builder.Property(a => a.UserName)
                .HasColumnName(nameof(Entity.UserName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.EntityNameMaxLength)
                .IsRequired();

            builder.Property(a => a.NormalizedEmail)
                .HasColumnName(nameof(Entity.NormalizedUserName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.NormalizedUserNameMaxLength)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName(nameof(Entity.Email))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.EmailMaxLength)
                .IsRequired();

            builder.Property(a => a.NormalizedEmail)
                .HasColumnName(nameof(Entity.NormalizedEmail))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.NormalizedEmailMaxLength)
                .IsRequired();

            builder.Property(a => a.EmailConfirmed)
                .HasColumnName(nameof(Entity.EmailConfirmed))
                .HasColumnType(SqlColumnTypesConstants.Bit);

            builder.Property(a => a.PasswordHash)
                .HasColumnName(nameof(Entity.PasswordHash))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.PasswordHasMaxLength)
                .IsRequired();

            builder.Property(a => a.ConcurrencyStamp)
                .HasColumnName(nameof(Entity.ConcurrencyStamp))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.ConcurrencyStampMaxLength)
                .IsConcurrencyToken()
                .IsRequired();

            builder.Property(a => a.SecurityStamp)
                .HasColumnName(nameof(Entity.SecurityStamp))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.SecurityStampMaxLength)
                .IsRequired();

            builder.Property(a => a.PhoneNumber)
                .HasColumnName(nameof(Entity.PhoneNumber))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.PhoneNumberMaxLength)
                .IsRequired(false);

            builder.Property(a => a.PhoneNumberConfirmed)
                .HasColumnName(nameof(Entity.PhoneNumberConfirmed))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .HasDefaultValue(false);

            builder.Property(a => a.TwoFactorEnabled)
                .HasColumnName(nameof(Entity.TwoFactorEnabled))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .HasDefaultValue(false);

            builder.Property(a => a.LockOutEnabled)
                .HasColumnName(nameof(Entity.LockOutEnabled))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .HasDefaultValue(false);

            builder.Property(a => a.LockOutEnd)
                .HasColumnName(nameof(Entity.LockOutEnd))
                .HasColumnType(SqlColumnTypesConstants.DateTime2)
                .IsRequired(false);

            builder.Property(a => a.AccessFailedCount)
                .HasColumnName(nameof(Entity.AccessFailedCount))
                .HasColumnType(SqlColumnTypesConstants.SmallInt)
                .HasDefaultValue(0);

            builder.Property(a => a.RefreshToken)
                .HasColumnName(nameof(Entity.RefreshToken))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityConfigurationConstants.RefreshTokenMaxLength)
                .IsRequired(false);

            builder.Property(a => a.RefreshTokenExpiryTime)
                .HasColumnName(nameof(Entity.RefreshTokenExpiryTime))
                .HasColumnType(SqlColumnTypesConstants.DateTime2)
                .IsRequired(false);

            // Each Entity have one EntityInformations
            builder.HasOne(a => a.EntityInformation)
                .WithOne(b => b.Entity)
                .HasForeignKey<EntityInformations>(c => c.EntityId)
                .IsRequired();

            // Each Entity can have many EntityClaims
            builder.HasMany<EntityClaims>(e => e.Claims)
                .WithOne(e => e.Entity)
                .HasForeignKey(uc => uc.EntityId)
                .IsRequired();

            // Each Entity can have many EntityLogins
            builder.HasMany<EntityLogin>(e => e.Logins)
                .WithOne(e => e.Entity)
                .HasForeignKey(ul => ul.EntityId)
                .IsRequired();

            // Each Entity can have many EntityTokens
            builder.HasMany<EntityTokens>(e => e.Tokens)
                .WithOne(e => e.Entity)
                .HasForeignKey(ut => ut.EntityId)
                .IsRequired();

            // Each Entity can have many entries in the EntityRole join table
            builder.HasMany<EntityRoles>(e => e.EntityRoles)
                .WithOne(e => e.Entity)
                .HasForeignKey(ur => ur.EntityId)
                .IsRequired();

            // Each Entity can have many entries in the VerificationCodes table
            builder.HasMany(a => a.EntityVerifications)
                .WithOne(a => a.Entity)
                .HasForeignKey(b => b.EntityId)
                .IsRequired();
        }
    }
}
