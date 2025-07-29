using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Register.Context;
using Domain.Errors;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Register.Process
{
    internal sealed class FindUserByEmailStep : Step<RegisterUserContext, Result<RegisterResponse>>
    {
        public override async Task<Result<RegisterResponse>> ExecuteAsync(RegisterUserContext context)
        {
            var exisitingUser = await context.UnitOfWork.EntityRepository.GetUserByEmailAsync(context.CommandRequest.Email);
            if(exisitingUser is not null)
            {
                context.Result = Result.Failure<RegisterResponse>(UserErrors.EmailNotUnique);
            }

            return await this.ExecuteNextAsync(context);
        }
    }
}
