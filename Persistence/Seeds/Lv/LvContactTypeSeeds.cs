using Domain.Constants;

namespace Persistence.Seeds.Lv
{
    public static class LvContactTypeSeeds
    {
        public static void AddSeedData(this EntityTypeBuilder<LvContactType> builder)
        {
            builder.HasData([
                new() {
                    Id = 1,
                    Code = ContactTypeCodeConstants.Email,
                    Name = "Email",
                    Description = "Email",
                    SortOrder = 10
                },
                new() {
                    Id = 2,
                    Code = ContactTypeCodeConstants.Phone,
                    Name = "Phone",
                    Description = "Phone",
                    SortOrder = 20
                },
                new() {
                    Id = 3,
                    Code = ContactTypeCodeConstants.Mobile,
                    Name = "Mobile",
                    Description = "Mobile",
                    SortOrder = 30
                },
                new() {
                    Id = 4,
                    Code = ContactTypeCodeConstants.Fax,
                    Name = "Fax",
                    Description = "Fax",
                    SortOrder = 40
                },
                new() {
                    Id = 5,
                    Code = ContactTypeCodeConstants.Website,
                    Name = "Website",
                    Description = "Website",
                    SortOrder = 50
                },
                new() {
                    Id = 6,
                    Code = ContactTypeCodeConstants.Facebook,
                    Name = "Facebook",
                    Description = "Facebook",
                    SortOrder = 60
                },
                new() {
                    Id = 7,
                    Code = ContactTypeCodeConstants.X,
                    Name = "X",
                    Description = "X",
                    SortOrder = 70
                },
                new() {
                    Id = 8,
                    Code = ContactTypeCodeConstants.Instagram,
                    Name = "Instagram",
                    Description = "Instagram",
                    SortOrder = 80
                },
                new() {
                    Id = 9,
                    Code = ContactTypeCodeConstants.Other,
                    Name = "Other",
                    Description = "Other",
                    SortOrder = 90
                },
            ]);
        }
    }
}
