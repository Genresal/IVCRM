using FluentValidation;
using IVCRM.Core.Constants;
using IVCRM.Core.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace IVCRM.API.Validators.Common;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, string> CheckEmailFormat<T>(this IRuleBuilder<T, string> ruleBuilder) where T : class
    {
        return ruleBuilder.ChildRules(x =>
        {
            x.RuleFor(s => s).Custom((email, context) =>
            {
                if (!string.IsNullOrEmpty(email) && !new EmailAddressAttribute().IsValid(email))
                    throw new WebApiException(ErrorCodes.INVALID_INPUTS, new List<FieldError>()
                    {
                        new() { Name = "email", Code = ErrorCodes.INVALID_EMAIL }
                    });
            });
        });
    }
}