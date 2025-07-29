namespace Persistence.Configuration.Identity
{
    public class EntityRolesConfiguration : IEntityTypeConfiguration<EntityRoles>
    {
        public void Configure(EntityTypeBuilder<EntityRoles> builder)
        {
            builder.ToTable(name: EntityRoleConfigurationConstants.TableName);
            builder.HasKey(a => new { a.EntityId, a.RoleId });

            builder.Property(a => a.EntityId)
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier)
                .IsRequired();

            builder.Property(a => a.RoleId)
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier)
                .IsRequired();
        }
    }
}
