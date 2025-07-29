namespace Application.Configurations
{
    public class AuthenticationSettings
    {
        public int AccessFailedCount { get; set; }
        public int LockoutTime { get; set; }
        public int VerificationCodeTime { get; set; }
    }
}
