using Application.Abstraction.Authentication;
using Application.Abstraction.Factories;
using Application.Abstraction.Messaging;
using Application.Abstraction.Services;
using Application.Configurations;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Login.Process;
using Application.Time;
using Domain.Primitives;
using Domain.Repositories;
using Microsoft.Extensions.Options;

namespace Application.Entity.Handlers.Commands.Login
{
    internal sealed class LoginUserCommandHandler(
        IUnitOfWork unitOfWork,
        IUserProcessFactory processFactory,
        IPasswordHasher passwordHasher,
        ITokenService tokenService,
        IAppLogService applogService,
        IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtSettings,
        IOptions<AuthenticationSettings> authenticationSettings) : ICommandHandler<LoginUserCommand, LoginEntityResponse>
    {
        public async Task<Result<LoginEntityResponse>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var response = new Result<LoginEntityResponse>(new LoginEntityResponse(), true, Error.None);

            var process = processFactory.CreaLoginUserProcess;
            var context = new LoginUserContext(unitOfWork, passwordHasher,
                tokenService, dateTimeProvider, applogService,
                jwtSettings.Value, authenticationSettings.Value) {
                CommandRequest = command, Result = response
            };
            var result = await process.ExecuteAsync(context);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
