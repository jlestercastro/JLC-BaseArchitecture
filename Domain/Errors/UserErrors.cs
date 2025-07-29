using Domain.Primitives;

namespace Domain.Errors
{
    public static class UserErrors
    {
        public static Error NotFound(Guid userId) => Error.NotFound(
            "Users.NotFound",
            $"The user with the Id = '{userId}' was not found");

        public static Error Unauthorized() => Error.Failure(
            "Users.Authorization",
            "You are not authorized to perform this action.");

        public static Error InvalidLoginCredentials => Error.Problem(
            "Users.Authorization",
            "Invalid login credentials.");

        public static readonly Error AccountLockOut = Error.Problem(
            "User.Authorization",
            "Your account is locked out. Please try again later.");

        public static readonly Error AccountHasBeenLockOut = Error.Problem(
            "User.Authorization",
            "Your account has been locked out due to multiple failed login attempts. Please try again later.");

        public static readonly Error InvalidTwoFACode = Error.Problem(
            "User.Verification",
            "Invalid two factor code. Please try again");

        public static readonly Error NotFoundByEmail = Error.NotFound(
            "Users.NotFoundByEmail",
            "The user with the specified email was not found");

        public static readonly Error EmailNotUnique = Error.Conflict(
            "Users.EmailNotUnique",
            "The provided email is not unique");

        public static readonly Error VerificationMaxAttempt = Error.Problem(
            "Users.Verification",
            "Verification code max attempt. Regenere new verification code.");
    }
}
