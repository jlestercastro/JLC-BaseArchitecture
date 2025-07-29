using Application.Abstraction.Authentication;
using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Time;
using Domain.Primitives;
using Domain.Repositories;

namespace Application.Entity.Handlers.Commands.Register.Context
{
    public sealed class RegisterUserContext(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IDateTimeProvider dateTimeProvider
        ) : StepContext<Result<RegisterResponse>>
    {
        public IUnitOfWork UnitOfWork { get; private set; } = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        public IPasswordHasher PasswordHasher { get; private set; } = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        public IDateTimeProvider DateTimeProvider { get; private set; } = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        public required RegisterUserCommand CommandRequest { get; set; } = default!;
        public Domain.Entities.Identity.Entity User { get; set; } = default!;
    }
}
