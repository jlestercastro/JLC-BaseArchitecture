using Application.Abstraction.Authentication;
using Application.Abstraction.Factories;
using Application.Abstraction.Messaging;
using Application.Time;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Register.Context;
using Domain.Primitives;
using Domain.Repositories;

namespace Application.Entity.Handlers.Commands.Register
{
    internal sealed class RegisterUserCommandHandler(
        IUnitOfWork unitOfWork,
        IUserProcessFactory processFactory,
        IPasswordHasher passwordHasher,
        IDateTimeProvider dateTimeProvider) : ICommandHandler<RegisterUserCommand, RegisterResponse>
    {
        public async Task<Result<RegisterResponse>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var response = new Result<RegisterResponse>(new RegisterResponse(), true, Error.None);

            var process = processFactory.CreateRegisterUserProcess;
            var context = new RegisterUserContext(unitOfWork, passwordHasher, dateTimeProvider) { CommandRequest = command, Result = response };
            var result = await process.ExecuteAsync(context);

            if (result.IsSuccess)
                await unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
