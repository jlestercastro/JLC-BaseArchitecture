using Application.Abstraction.Messaging;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Register;
using Domain.Primitives;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Entity
{
    internal sealed class Register : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("users/register", async (
                RegisterRequest request,
                ICommandHandler<RegisterUserCommand, RegisterResponse> handler,
                CancellationToken cancellationToken) =>
            {
                Result<RegisterResponse> result = await handler.Handle(request.AsCommand(), cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Users);
        }
    }
}
