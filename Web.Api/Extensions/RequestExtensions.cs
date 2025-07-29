using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Login;
using Application.Entity.Handlers.Commands.Register;
using Application.Entity.Handlers.Commands.Verify2FALogin;

namespace Web.Api.Extensions
{
    public static class RequestExtensions
    {
        public static RegisterUserCommand AsCommand(this RegisterRequest request)
            =>new RegisterUserCommand(request.IsIndividual, request.Email, request.Password);
        public static LoginUserCommand AsCommand(this LoginEntityRequest request) 
            => new LoginUserCommand(request.Email, request.Password);
        public static VerifyTwoFACommand AsCommand(this VerifyTwoFARequest request)
            => new VerifyTwoFACommand(request.UserId, request.ReferenceId, request.Code);
    }
}
