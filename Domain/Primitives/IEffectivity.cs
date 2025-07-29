namespace Domain.Primitives
{
    public interface IEffectivity
    {
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
