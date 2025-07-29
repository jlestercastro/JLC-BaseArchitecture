using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Constants;
using Domain.Errors;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.VerifyTwoFALogin.Process
{
    internal sealed class ValidateUserTwoFAVerificationCodeStep : Step<VerifyTwoFAContext, Result<VerifyTwoFAResponse>>
    {
        public override async Task<Result<VerifyTwoFAResponse>> ExecuteAsync(VerifyTwoFAContext context)
        {
            context.User = await context.UnitOfWork.EntityRepository.GetUserWithVerificationsByIdAsync(
                context.CommandRequest.UserId,
                context.CommandRequest.ReferenceId,
                VerificationTypeCodeConstants.TwoFactorAuthentication
            );

            var userVerification = context.User.EntityVerifications.First();

            if (userVerification is not null &&
                !userVerification.Code.Equals(context.CommandRequest.Code) &&
                userVerification.FailedAttempt <= 3)
            {
                userVerification.FailedAttempt += 1;
                context.Result = Result.Failure<VerifyTwoFAResponse>(UserErrors.InvalidTwoFACode);
            }
            else
            {
                if(userVerification.FailedAttempt > 3)
                {
                    userVerification.IsUsed = false;
                    userVerification.AdditionalData = "Verification code max attempt. Regenere new verification code.";
                    context.Result = Result.Failure<VerifyTwoFAResponse>(UserErrors.VerificationMaxAttempt);
                }
                else
                {
                    userVerification.IsUsed = true;
                    userVerification.UsedDate = context.DateTimeProvider.UtcNow;
                }
            }

            context.UnitOfWork.VerificationCodesRepository.Update(userVerification);

            return await this.ExecuteNextAsync(context);
        }
    }
}
