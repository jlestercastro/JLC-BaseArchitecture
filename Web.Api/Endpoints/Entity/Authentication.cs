using Application.Abstraction.Messaging;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Login;
using Application.Entity.Handlers.Commands.Verify2FALogin;
using Domain.Primitives;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Entity
{
    internal sealed class Authentication : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("auth/login", async (
                LoginEntityRequest request,
                ICommandHandler<LoginUserCommand, LoginEntityResponse> handler,
                CancellationToken cancellationToken) =>
            {
                Result<LoginEntityResponse> result = await handler.Handle(request.AsCommand(), cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Authentication);

            app.MapPost("auth/verify-two-fa", async (
                VerifyTwoFARequest request,
                ICommandHandler<VerifyTwoFACommand, VerifyTwoFAResponse> handler,
                CancellationToken cancellationToken) =>
            {
                Result<VerifyTwoFAResponse> result = await handler.Handle(request.AsCommand(), cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Authentication);
        }
    }
}
