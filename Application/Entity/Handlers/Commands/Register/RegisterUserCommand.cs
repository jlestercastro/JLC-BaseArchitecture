using Application.Abstraction.Messaging;
using Application.Entity.DTOs;

namespace Application.Entity.Handlers.Commands.Register
{
    public sealed record RegisterUserCommand(
        bool IsIndividual,
        string Email,
        string Password) : ICommand<RegisterResponse>
    { }
}
