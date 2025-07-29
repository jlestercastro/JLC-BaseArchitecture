namespace Application.Entity.DTOs
{
    public class VerifyTwoFARequest
    {
        public Guid UserId { get; set; }
        public string ReferenceId { get; set; }
        public string Code { get; set; }
    }
}
