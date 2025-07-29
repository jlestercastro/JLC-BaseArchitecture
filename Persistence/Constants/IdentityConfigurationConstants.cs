namespace Persistence.Constants
{
    public class AddressConfigurationConstants
    {
        public const string TableName = "Address";
        public const int StreetAddress1MaxLength = 100;
        public const int StreetAddress2MaxLength = 100;
        public const int ZipCodeMaxLength = 15;
        public const int PostalCodeMaxLength = 15;
        public const int CityMaxLength = 100;
        public const int StateMaxLength = 100;
        public const int ProvinceMaxLength = 100;
        public const int CountyMaxLength = 100;
        public const int CountryCodeMaxLength = 100;
        public const int FullAddressMaxLength = 500;
    }
    public class RefreshTokenConfigurationConstants
    {
        public const string TableName = "RefreshToken";
        public const int TokenMaxLength = 1000;
        public const int JwtIdMaxLength = 200;
    }
    public class RoleClaimsConfigurationConstants
    {
        public const string TableName = "RoleClaim";
        public const int ClaimTypeMaxLength = 100;
        public const int ClaimValueMaxLength = 300;
    }
    public class RoleConfigurationConstants
    {
        public const string TableName = "Role";
        public const string RoleNameIndex = "RoleNameIndex";
        public const int NameMaxLength = 200;
        public const int NormalizedNameMaxLength = 200;
        public const int ConcurrencyStampMaxLength = 300;
    }
    public partial class EntityAddressConfigurationConstants
    {
        public const string TableName = "EntityAddress";
    }
    public class EntityClaimsConfigurationConstants
    {
        public const string TableName = "EntityClaim";
        public const int ClaimTypeMaxLength = 100;
        public const int ClaimValueMaxLength = 300;
    }
    public class EntityConfigurationConstants
    {
        public const string TableName = "Entity";
        public const int EntityNameMaxLength = 100;
        public const int NormalizedUserNameMaxLength = 100;
        public const int EmailMaxLength = 100;
        public const int NormalizedEmailMaxLength = 100;
        public const int PasswordHasMaxLength = 200;
        public const int SecurityStampMaxLength = 200;
        public const int ConcurrencyStampMaxLength = 200;
        public const int PhoneNumberMaxLength = 50;
        public const int RefreshTokenMaxLength = 1000;
    }
    public class EntityContactConfigurationConstants
    {
        public const string TableName = "EntityContact";
    }
    public class EntityInformationConfigurationConstants
    {
        public const string TableName = "EntityInformation";
        public const int FirstNameMaxLength = 100;
        public const int MiddleNameMaxLength = 100;
        public const int LastNameMaxLength = 100;
        public const int SuffixMaxLength = 50;
        public const int GenderMaxLength = 100;
        public const int CompanyNameMaxLength = 200;
    }
    public class EntityLoginsConfigurationConstants
    {
        public const string TableName = "EntityLogin";
        public const int LoginProviderMaxLength = 100;
        public const int ProviderKeyMaxLength = 100;
        public const int ProviderDisplayNameMaxLength = 200;
    }
    public partial class EntityRoleConfigurationConstants
    {
        public const string TableName = "EntityRole";
    }
    public class EntityTokensConfigurationConstants
    {
        public const string TableName = "EntityToken";
        public const int LoginProviderMaxLength = 250;
        public const int NameMaxLength = 100;
        public const int ValueMaxLength = 1500;
    }
    public class VerificationCodesConfigurationConstants
    {
        public const string TableName = "VerificationCodes";
        public const int CodeMaxLength = 100;
        public const int VerificationCodeTypeMaxLength = 30;
        public const int IpAddressMaxLength = 100;
        public const int AdditionalDataMaxLength = 500;
    }

    #region Logging

    public class AppLogConfiguration
    {
        public const string TableName = "AppLog";
    }

    #endregion
}
