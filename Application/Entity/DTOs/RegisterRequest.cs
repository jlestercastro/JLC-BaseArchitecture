namespace Application.Entity.DTOs
{
    public sealed class RegisterRequest
    {
        public bool IsIndividual { get; set; } = true;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
