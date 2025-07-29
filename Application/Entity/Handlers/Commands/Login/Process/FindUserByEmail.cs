using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Errors;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    internal sealed class FindUserByEmailStep : Step<LoginUserContext, Result<LoginEntityResponse>>
    {
        public override async Task<Result<LoginEntityResponse>> ExecuteAsync(LoginUserContext context)
        {
            context.User = await context.UnitOfWork.EntityRepository.GetUserWithAuthenticationDetailsByEmailAsync(context.CommandRequest.Email);

            if(context.User is null)
            {
                context.Result = Result.Failure<LoginEntityResponse>(UserErrors.InvalidLoginCredentials);
            }

            return await this.ExecuteNextAsync(context);
        }
    }
}
