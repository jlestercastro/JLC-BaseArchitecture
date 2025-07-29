using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Constants;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    internal sealed class VerifyUserTwoFAStep : Step<LoginUserContext, Result<LoginEntityResponse>>
    {
        public override async Task<Result<LoginEntityResponse>> ExecuteAsync(LoginUserContext context)
        {
            if(context.User.TwoFactorEnabled && context.IsVerified)
            {
                var twoFactorVerification = context.TokenService.GenerateUserVerifications(context.User, VerificationTypeCodeConstants.TwoFactorAuthentication);
                context.User.EntityVerifications.Add(twoFactorVerification);
                context.Result.Value.TwoFactorEnabled = true;
                context.Result.Value.TwoFactorReferenceId = twoFactorVerification.ReferenceId;
                context.Result.Value.UserId = context.User.Id;

                context.UnitOfWork.EntityRepository.Update(context.User);
                return context.Result;
            }

            return await this.ExecuteNextAsync(context);
        }
    }
}
