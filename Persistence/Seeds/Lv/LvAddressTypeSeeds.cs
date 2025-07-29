using Domain.Constants;

namespace Persistence.Seeds.Lv
{
    public static class LvAddressTypeSeeds
    {
        public static void AddSeedData(this EntityTypeBuilder<LvAddressType> builder)
        {
            builder.HasData([
                new() {
                    Id = 1,
                    Code = AddressTypeCodeConstants.Home,
                    Name = "Home",
                    Description = "Home",
                    SortOrder = 10
                },
                new() {
                    Id = 2,
                    Code = AddressTypeCodeConstants.Work,
                    Name = "Work",
                    Description = "Work",
                    SortOrder = 20
                },
                new() {
                    Id = 3,
                    Code = AddressTypeCodeConstants.Billing,
                    Name = "Billing",
                    Description = "Billing",
                    SortOrder = 30
                },
                new() {
                    Id = 4,
                    Code = AddressTypeCodeConstants.Shipping,
                    Name = "Shipping",
                    Description = "Shipping",
                    SortOrder = 40
                },
                new() {
                    Id = 5,
                    Code = AddressTypeCodeConstants.Other,
                    Name = "Other",
                    Description = "Other",
                    SortOrder = 50
                },
            ]);
        }
    }
}
