using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Register.Context;
using Domain.Entities.Identity;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Register.Process
{
    internal sealed class CreateUserStep : Step<RegisterUserContext, Result<RegisterResponse>>
    {
        public override async Task<Result<RegisterResponse>> ExecuteAsync(RegisterUserContext context)
        {
            context.User = new Domain.Entities.Identity.Entity
            {
                Id = Guid.NewGuid(),
                Email = context.CommandRequest.Email,
                NormalizedEmail = context.CommandRequest.Email.ToUpper(),
                UserName = context.CommandRequest.Email,
                NormalizedUserName = context.CommandRequest.Email.ToUpper(),
                TwoFactorEnabled = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EntityInformation = new EntityInformations
                {
                    IsIndividual = context.CommandRequest.IsIndividual
                }
            };

            context.Result.Value.UserId = context.User.Id;

            return await this.ExecuteNextAsync(context);
        }
    }
}
