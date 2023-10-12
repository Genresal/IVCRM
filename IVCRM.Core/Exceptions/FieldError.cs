using Swashbuckle.AspNetCore.Annotations;

namespace IVCRM.Core.Exceptions;

public class FieldError : BaseError
{
    public FieldError() { }

    public FieldError(string code, string name)
    {
        Code = code;
        Name = name;
    }

    /// <summary>
    /// Field name for this specific error
    /// </summary>
    [SwaggerParameter(Required = true,
        Description = "Name of the field where was found the error")]
    public string Name { get; init; } = String.Empty;
}