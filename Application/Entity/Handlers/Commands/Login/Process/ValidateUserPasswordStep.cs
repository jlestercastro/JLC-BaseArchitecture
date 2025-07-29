using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Errors;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    internal sealed class ValidateUserPasswordStep : Step<LoginUserContext, Result<LoginEntityResponse>>
    {
        public override async Task<Result<LoginEntityResponse>> ExecuteAsync(LoginUserContext context)
        {
            if (context.User is not null)
            {
                context.IsVerified = context.PasswordHasher.Verify(context.CommandRequest.Password, context.User.PasswordHash);

                if(!context.User.LockOutEnabled && !context.IsVerified)
                {
                    context.Result = Result.Failure<LoginEntityResponse>(UserErrors.InvalidLoginCredentials);
                }
            }

            return await this.ExecuteNextAsync(context);
        }
    }
}
