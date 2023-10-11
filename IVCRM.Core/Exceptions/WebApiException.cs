namespace IVCRM.Core.Exceptions;

public class WebApiException : Exception
{
    private readonly string _errorCode;

    private readonly IList<FieldError> _fields;

    public WebApiException(string errorCode) : base(errorCode)
    {
        _errorCode = errorCode;
        _fields = new List<FieldError>();
    }

    public WebApiException(string errorCode, List<FieldError> fields) : base(errorCode)
    {
        _errorCode = errorCode;
        _fields = fields;
    }

    public string GetErrorCode()
    {
        return _errorCode;
    }

    public IList<FieldError> GetFields()
    {
        return _fields;
    }

    public void AddFieldError(string name, string code, string message)
    {
        AddFieldError(new FieldError
        {
            Name = name,
            Code = code
        });
    }

    public void AddFieldError(FieldError fieldError)
    {
        if (fieldError != null)
        {
            _fields.Add(fieldError);
        }
    }

    public void ClearFields()
    {
        _fields.Clear();
    }
}