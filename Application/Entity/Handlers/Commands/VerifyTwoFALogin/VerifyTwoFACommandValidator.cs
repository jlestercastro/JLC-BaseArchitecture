using FluentValidation;

namespace Application.Entity.Handlers.Commands.Verify2FALogin
{
    internal class VerifyTwoFACommandValidator : AbstractValidator<VerifyTwoFACommand>
    {
        public VerifyTwoFACommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.ReferenceId).NotEmpty();
            RuleFor(c => c.Code).NotEmpty();
        }
    }
}
