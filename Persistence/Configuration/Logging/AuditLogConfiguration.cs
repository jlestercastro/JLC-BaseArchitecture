namespace Persistence.Configuration.Logging
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable(name: AuditLogConfigurationConstants.TableName);
            builder.HasIndex(a => new
            {
                a.Timestamp,
                a.EventType,
                a.TableName,
                a.UserId
            });

            builder.Property(a => a.Timestamp)
                .HasColumnName(nameof(AuditLog.Timestamp))
                .HasColumnType(SqlColumnTypesConstants.DateTime2)
                .IsRequired();

            builder.Property(a => a.EventType)
                .HasColumnName(nameof(AuditLog.EventType))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AuditLogConfigurationConstants.EventTypeMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired();

            builder.Property(a => a.TableName)
                .HasColumnName(nameof(AuditLog.TableName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AuditLogConfigurationConstants.TableNameMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired();

            builder.Property(a => a.RecordId)
                .HasColumnName(nameof(AuditLog.RecordId))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AuditLogConfigurationConstants.RecordIdMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired();

            builder.Property(a => a.UserId)
                .HasColumnName(nameof(AuditLog.UserId))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AuditLogConfigurationConstants.UserIdMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.HttpMethod)
                .HasColumnName(nameof(AuditLog.HttpMethod))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AuditLogConfigurationConstants.HttpMethodMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired();

            builder.Property(a => a.Endpoint)
                .HasColumnName(nameof(AuditLog.Endpoint))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AuditLogConfigurationConstants.EndpointMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired();

            builder.Property(a => a.OldValues)
                .HasColumnName(nameof(AuditLog.OldValues))
                .HasColumnType(SqlColumnTypesConstants.VarcharMax)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false);

            builder.Property(a => a.NewValues)
                .HasColumnName(nameof(AuditLog.NewValues))
                .HasColumnType(SqlColumnTypesConstants.VarcharMax)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false); ;

            builder.Property(a => a.ChangedColumns)
                .HasColumnName(nameof(AuditLog.ChangedColumns))
                .HasColumnType(SqlColumnTypesConstants.VarcharMax)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false); ;
        }
    }
}
