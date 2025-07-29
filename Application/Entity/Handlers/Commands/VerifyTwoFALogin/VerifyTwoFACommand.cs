using Application.Abstraction.Messaging;
using Application.Entity.DTOs;

namespace Application.Entity.Handlers.Commands.Verify2FALogin
{
    public sealed record VerifyTwoFACommand(Guid UserId, string ReferenceId, string Code) 
        : ICommand<VerifyTwoFAResponse> 
    { }
}
