using FluentValidation;
using IVCRM.Core.Constants;
using IVCRM.Core.Exceptions;
using IVCRM.Core.Models.Common;

namespace IVCRM.API.Validators.Common
{
    public class SortedRequestValidator : AbstractValidator<SortedRequest>
    {
        public SortedRequestValidator()
        {
            Include(new PagedRequestValidator());

            RuleFor(x => x).Custom((model, _) =>
            {
                if (!string.IsNullOrEmpty(model.OrderBy) && !model.OrderBy.Contains(':'))
                {
                    throw new WebApiException(errorCode: ErrorCodes.INVALID_INPUTS, new List<FieldError>()
                    {
                        new()
                        {
                            Code = ErrorCodes.INVALID_ORDER_BY,
                            Name = "sortedRequest.orderBy"
                        }
                    });
                }
            });
        }
    }
}
