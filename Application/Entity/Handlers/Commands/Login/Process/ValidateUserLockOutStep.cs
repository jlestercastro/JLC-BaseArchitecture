using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Errors;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    internal sealed class ValidateUserLockOutStep : Step<LoginUserContext, Result<LoginEntityResponse>>
    {
        public override async Task<Result<LoginEntityResponse>> ExecuteAsync(LoginUserContext context)
        {
            if(context.User is not null && context.User.LockOutEnabled)
            {
                bool isLocked = false;
                if (context.User.LockOutEnd is not null && context.DateTimeProvider.UtcNow <= context.User.LockOutEnd)
                {
                    context.Result = Result.Failure<LoginEntityResponse>(UserErrors.AccountLockOut);
                    isLocked = true;
                }

                if(!isLocked)
                {
                    if (context.IsVerified)
                    {
                        context.User.AccessFailedCount = 0;
                        context.User.LockOutEnd = null;
                    }
                    else
                    {
                        context.User.AccessFailedCount = context.User.AccessFailedCount == context.AuthenticationSettings.AccessFailedCount ? 1 : (context.User.AccessFailedCount + 1);
                        context.Result = Result.Failure<LoginEntityResponse>(UserErrors.InvalidLoginCredentials);

                        if (context.User.AccessFailedCount >= context.AuthenticationSettings.AccessFailedCount)
                        {
                            // Add Applog User Lockout START
                            context.User.LockOutEnd = context.DateTimeProvider.UtcNow.AddMinutes(context.AuthenticationSettings.LockoutTime);
                            context.Result = Result.Failure<LoginEntityResponse>(UserErrors.AccountHasBeenLockOut);
                        }

                        context.UnitOfWork.EntityRepository.Update(context.User);
                    }
                }
            }

            return await this.ExecuteNextAsync(context);
        }
    }
}
