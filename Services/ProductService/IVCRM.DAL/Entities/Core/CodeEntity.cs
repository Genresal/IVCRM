namespace IVCRM.DAL.Entities.Core;

public abstract class CodeEntity : Entity, ICodeEntity
{
    public string Code { get; set; } = string.Empty;
}