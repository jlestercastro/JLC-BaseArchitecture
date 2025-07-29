namespace Persistence.Constants
{
    internal static class SqlDefaultConstants
    {
        public const string SqlGuidDefaultValue = "newid()";
        public const string SqlDateTimeDefaultValue = "getutcdate()";
        public const bool SqlBitDefaultValue = true;
        public const bool SqlUnicodeDefaultValue = false;
    }

    internal static class SqlColumnTypesConstants
    {
        public const string Varchar = "varchar";
        public const string VarcharMax = "varchar(MAX)";
        public const string Decimal = "decimal";
        public const string UniqueIdentifier = "uniqueidentifier";
        public const string BigInt = "bigint";
        public const string DateTimeOffset = "datetimeoffset";
        public const string DateTime2 = "datetime2(7)";
        public const string Date = "date";
        public const string Int = "int";
        public const string Bit = "bit";
        public const string Decimal108 = "decimal(10,8)";
        public const string SmallInt = "smallint";
    }
}
