using FluentValidation;

namespace Application.Entity.Handlers.Commands.Register
{
    internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                .MaximumLength(50).WithMessage("Password cannot exceed 50 characters")
                .Must(ContainUpperCase).WithMessage("Password must contain at least one uppercase letter")
                .Must(ContainLowerCase).WithMessage("Password must contain at least one lowercase letter")
                .Must(ContainNumber).WithMessage("Password must contain at least one number")
                .Must(ContainSpecialCharacter).WithMessage("Password must contain at least one special character");
        }

        private bool ContainUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool ContainLowerCase(string password)
        {
            return password.Any(char.IsLower);
        }

        private bool ContainNumber(string password)
        {
            return password.Any(char.IsDigit);
        }

        private bool ContainSpecialCharacter(string password)
        {
            // Define what you consider special characters
            var specialCharacters = "!@#$%^&*()-_=+[]{}|;:',.<>/?";
            return password.Any(c => specialCharacters.Contains(c));
        }
    }
}
