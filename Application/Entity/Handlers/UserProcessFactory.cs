using Application.Abstraction.Factories;
using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Login.Process;
using Application.Entity.Handlers.Commands.Register.Context;
using Application.Entity.Handlers.Commands.Register.Process;
using Application.Entity.Handlers.Commands.VerifyTwoFALogin.Process;
using Domain.Primitives;

namespace Application.Entity.Handlers
{
    public sealed class UserProcessFactory : IUserProcessFactory
    {
        public IStep<RegisterUserContext, Result<RegisterResponse>> CreateRegisterUserProcess
        {
            get
            {
                var process = new Commands.Register.Process.FindUserByEmailStep();
                process.SetSuccessor(new CreateUserStep());
                process.SetSuccessor(new CreateUserPasswordHashStep());
                process.SetSuccessor(new CreateUserClaimStep());
                process.SetSuccessor(new RaiseUserRegisterDomainEventStep());

                return process;
            }
        }

        public IStep<LoginUserContext, Result<LoginEntityResponse>> CreaLoginUserProcess
        {
            get
            {
                var process = new Commands.Login.Process.FindUserByEmailStep();
                process.SetSuccessor(new ValidateUserPasswordStep());
                process.SetSuccessor(new ValidateUserLockOutStep());
                process.SetSuccessor(new VerifyUserTwoFAStep());
                process.SetSuccessor(new Send2FAAuthenticationCodeStep());
                process.SetSuccessor(new GenerateAccessTokenStep());
                process.SetSuccessor(new Commands.Login.Process.RaiseUserLoginDomainEventStep());

                return process;
            }
        }

        public IStep<VerifyTwoFAContext, Result<VerifyTwoFAResponse>> CreateVerifyTwoFALoginProcess
        {
            get
            {
                var process = new ValidateUserTwoFAVerificationCodeStep();
                process.SetSuccessor(new GenerateTwoFAAccessTokenStep());
                process.SetSuccessor(new Commands.VerifyTwoFALogin.Process.RaiseUserLoginDomainEventStep());

                return process;
            }
        }
    }
}
