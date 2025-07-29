using Application.Abstraction.Authentication;
using Application.Abstraction.Steps;
using Application.Configurations;
using Application.Time;
using Application.Entity.DTOs;
using Domain.Entities.Identity;
using Domain.Primitives;
using Domain.Repositories;
using Application.Abstraction.Services;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    public sealed class LoginUserContext(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        ITokenService tokenService,
        IDateTimeProvider dateTimeProvider,
        IAppLogService applogService,
        JwtSettings jwtSettings,
        AuthenticationSettings authenticationSettings
        ) : StepContext<Result<LoginEntityResponse>>
    {
        public IUnitOfWork UnitOfWork { get; private set; } = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        public IPasswordHasher PasswordHasher { get; private set; } = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        public ITokenService TokenService { get; private set; } = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        public IDateTimeProvider DateTimeProvider { get; private set; } = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        public IAppLogService AppLogService { get; private set; } = applogService ?? throw new ArgumentNullException(nameof(applogService));
        public JwtSettings JwtSettings { get; private set; } = jwtSettings ?? throw new ArgumentNullException(nameof(jwtSettings));
        public AuthenticationSettings AuthenticationSettings { get; private set; } = authenticationSettings ?? throw new ArgumentNullException(nameof(authenticationSettings));
        public required LoginUserCommand CommandRequest { get; set; } = default!;
        public Domain.Entities.Identity.Entity User { get; set; } = default!;
        public bool IsVerified { get; set; }
    }
}
