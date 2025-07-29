namespace Application.Entity.DTOs
{
    public class LoginEntityResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresIn { get; set; }
        public bool TwoFactorEnabled { get; set; } = false;
        public string TwoFactorReferenceId { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
