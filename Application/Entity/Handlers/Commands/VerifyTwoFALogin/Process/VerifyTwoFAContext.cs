using Application.Abstraction;
using Application.Abstraction.Authentication;
using Application.Abstraction.Steps;
using Application.Configurations;
using Application.Time;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Verify2FALogin;
using Domain.Entities.Identity;
using Domain.Primitives;
using Domain.Repositories;

namespace Application.Entity.Handlers.Commands.VerifyTwoFALogin.Process
{
    public sealed class VerifyTwoFAContext(
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        IDateTimeProvider dateTimeProvider,
        IEntityContext userContext,
        JwtSettings jwtSettings
        ) : StepContext<Result<VerifyTwoFAResponse>>
    {
        public IUnitOfWork UnitOfWork { get; private set; } = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        public ITokenService TokenService { get; private set; } = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        public IDateTimeProvider DateTimeProvider { get; private set; } = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        public IEntityContext UserContext { get; private set; } = userContext ?? throw new ArgumentNullException(nameof(userContext));
        public JwtSettings JwtSettings { get; private set; } = jwtSettings ?? throw new ArgumentNullException(nameof(jwtSettings));
        public required VerifyTwoFACommand CommandRequest { get; set; } = default!;
        public Domain.Entities.Identity.Entity User { get; set; } = default!;
    }
}
