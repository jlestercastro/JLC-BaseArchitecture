using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Register.Context;
using Domain.Entities.Identity;
using Domain.Primitives;
using Microsoft.AspNetCore.Identity;

namespace Application.Entity.Handlers.Commands.Register.Process
{
    internal sealed class CreateUserPasswordHashStep : Step<RegisterUserContext, Result<RegisterResponse>>
    {
        public override async Task<Result<RegisterResponse>> ExecuteAsync(RegisterUserContext context)
        {
            context.User.PasswordHash = context.PasswordHasher.Hash(context.CommandRequest.Password);

            return await this.ExecuteNextAsync(context);
        }
    }
}
