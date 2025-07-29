using Application.Abstraction;
using Application.Abstraction.Authentication;
using Application.Abstraction.Factories;
using Application.Abstraction.Messaging;
using Application.Configurations;
using Application.Time;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.VerifyTwoFALogin.Process;
using Domain.Primitives;
using Domain.Repositories;
using Microsoft.Extensions.Options;

namespace Application.Entity.Handlers.Commands.Verify2FALogin
{
    internal sealed class VerifyTwoFACommandHandler(
        IUnitOfWork unitOfWork,
        IUserProcessFactory processFactory,
        ITokenService tokenService,
        IDateTimeProvider dateTimeProvider,
        IEntityContext userContext,
        IOptions<JwtSettings> jwtSettings) : ICommandHandler<VerifyTwoFACommand, VerifyTwoFAResponse>
    {
        public async Task<Result<VerifyTwoFAResponse>> Handle(VerifyTwoFACommand command, CancellationToken cancellationToken)
        {
            var response = new Result<VerifyTwoFAResponse>(new VerifyTwoFAResponse(), true, Error.None);

            var process = processFactory.CreateVerifyTwoFALoginProcess;
            var context = new VerifyTwoFAContext(unitOfWork, tokenService, dateTimeProvider, userContext, jwtSettings.Value) { CommandRequest = command, Result = response };
            var result = await process.ExecuteAsync(context);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
