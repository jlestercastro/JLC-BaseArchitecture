namespace Persistence.Seeds
{
    public static class RoleSeeds
    {
        public static void AddSeedData(this EntityTypeBuilder<Roles> builder)
        {
            builder.HasData([
                new Roles() {
                    Id= Guid.Parse("00000000-0000-0000-0000-000000000001") ,
                    Name="Administrator",
                    NormalizedName= "ADMINISTRATOR",
                    ConcurrencyStamp="d188567a-4bdf-439a-8f02-b1df7ca791c6"
                },
                new Roles() {
                    Id= Guid.Parse("00000000-0000-0000-0000-000000000002") ,
                    Name="Manager",
                    NormalizedName= "MANAGER",
                    ConcurrencyStamp = "accdb00c-13dc-47e4-a400-939998b7b9d7"
                },
                new Roles() {
                    Id= Guid.Parse("00000000-0000-0000-0000-000000000003") ,
                    Name="User",
                    NormalizedName= "USER",
                    ConcurrencyStamp = "28d2028c-7382-4f4c-9667-951ce7493ebd"
                },
                new Roles() {
                    Id= Guid.Parse("00000000-0000-0000-0000-000000000004") ,
                    Name="Guest",
                    NormalizedName= "GUEST",
                    ConcurrencyStamp = "908dd5cf-625e-4a71-b9d9-95aa0ebefca4"
                },
            ]);
        }
    }
}
