using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Register.Context;
using Domain.Entities.Identity;
using Domain.Primitives;
using System.Security.Claims;

namespace Application.Entity.Handlers.Commands.Register.Process
{
    internal sealed class CreateUserClaimStep : Step<RegisterUserContext, Result<RegisterResponse>>
    {
        public override async Task<Result<RegisterResponse>> ExecuteAsync(RegisterUserContext context)
        {
            context.User.Claims = new List<EntityClaims>()
            {
                new() { ClaimType = ClaimTypes.NameIdentifier, ClaimValue = context.User.Id.ToString() },
                new() { ClaimType = ClaimTypes.Name, ClaimValue = context.User.UserName },
                new() { ClaimType = ClaimTypes.Email, ClaimValue = context.User.Email },
                new() { ClaimType = "SecurityStamp", ClaimValue = context.User.SecurityStamp },
            };

            return await this.ExecuteNextAsync(context);
        }
    }
}
