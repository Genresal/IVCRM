using FluentValidation;
using IVCRM.Core.Constants;
using IVCRM.Core.Exceptions;
using IVCRM.Core.Models.Common;

namespace IVCRM.API.Validators.Common
{
    public class PagedRequestValidator : AbstractValidator<PagedRequest>
    {
        public PagedRequestValidator()
        {
            RuleFor(x => x).Custom((model, _) =>
            {
                if (model.Page <= 0)
                {
                    throw new WebApiException(errorCode: ErrorCodes.INVALID_INPUTS, new List<FieldError>()
                    {
                        new()
                        {
                            Code = ErrorCodes.INVALID_PAGE,
                            Name = "pagedRequest.page"
                        }
                    });
                }
            });

            RuleFor(x => x).Custom((model, _) =>
            {
                if (model.PageSize <= 0)
                {
                    throw new WebApiException(errorCode: ErrorCodes.INVALID_INPUTS, new List<FieldError>()
                    {
                        new()
                        {
                            Code = ErrorCodes.INVALID_PAGE_SIZE,
                            Name = "pagedRequest.pageSize"
                        }
                    });
                }
            });
        }
    }
}
