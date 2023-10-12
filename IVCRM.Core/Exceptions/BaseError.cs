using IVCRM.Core.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace IVCRM.Core.Exceptions;

/// <summary>
/// Api error model for return error information to client
/// </summary>
[SwaggerSchema(Description = "Error structure is provided into the [API Guideline](#https://docs.google.com/document/d/1d1ImvwRkRv7YRiwMtt8aLaCGZAtXrQ2YFDjoC3W1ULg/edit#heading=h.nk1u3s936xst)")]
public abstract class BaseError
{
    /// <summary>
    /// specific code of error
    /// </summary>
    [SwaggerParameter(Description = "Pseudo-Human readable code to describe the error", Required = true)]
    public string Code { get; init; } = ErrorCodes.NOT_USE_IT_ERROR;
}