using Domain.Constants;

namespace Persistence.Seeds.Lv
{
    public static class LvVerificationCodeTypeSeeds
    {
        public static void AddSeedData(this EntityTypeBuilder<LvVerificationType> builder)
        {
            builder.HasData([
                new() {
                    Id = 1,
                    Code = VerificationTypeCodeConstants.TwoFactorAuthentication,
                    Name = "Two Factor Authentication",
                    Description = "Two Factor Authentication",
                    SortOrder = 10
                },
                new() {
                    Id = 2,
                    Code = VerificationTypeCodeConstants.Email,
                    Name = "Email Verification",
                    Description = "Email Veiriication",
                    SortOrder = 20
                },
                new() {
                    Id = 3,
                    Code = VerificationTypeCodeConstants.Phone,
                    Name = "Phone Verification",
                    Description = "Phone Verification",
                    SortOrder = 30
                },
                new() {
                    Id = 4,
                    Code = VerificationTypeCodeConstants.PasswordReset,
                    Name = "Password Reset Verification",
                    Description = "Password Reset Verification",
                    SortOrder = 40
                },
                new() {
                    Id = 5,
                    Code = VerificationTypeCodeConstants.AccountRecover,
                    Name = "Account Recovery Verification",
                    Description = "Account Recovery Verification",
                    SortOrder = 50
                },
            ]);
        }
    }
}
