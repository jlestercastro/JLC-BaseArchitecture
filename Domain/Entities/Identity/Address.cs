using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class Address : BaseEntity<Guid>
    {
        public string? StreetAddress1 { get; set; }
        public string? StreetAddress2 { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Province { get; set; }
        public string? County { get; set; }
        public string? CountryCode { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string? FullAddress { get; set; }

        public bool IsActive { get; set; }
        public virtual EntityAddress? UserAddresses { get; set; }
    }
}
