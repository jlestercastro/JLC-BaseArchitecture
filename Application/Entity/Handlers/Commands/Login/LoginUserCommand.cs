using Application.Abstraction.Messaging;
using Application.Entity.DTOs;

namespace Application.Entity.Handlers.Commands.Login
{
    public sealed record LoginUserCommand(
        string Email,
        string Password) : ICommand<LoginEntityResponse>
    { }
}
