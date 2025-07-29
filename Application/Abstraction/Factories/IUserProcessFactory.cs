using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Login.Process;
using Application.Entity.Handlers.Commands.Register.Context;
using Application.Entity.Handlers.Commands.VerifyTwoFALogin.Process;
using Domain.Primitives;

namespace Application.Abstraction.Factories
{
    public interface IUserProcessFactory : IFactory
    {
        IStep<RegisterUserContext, Result<RegisterResponse>> CreateRegisterUserProcess { get; }
        IStep<LoginUserContext, Result<LoginEntityResponse>> CreaLoginUserProcess { get; }
        IStep<VerifyTwoFAContext, Result<VerifyTwoFAResponse>> CreateVerifyTwoFALoginProcess { get; }
    }
}
