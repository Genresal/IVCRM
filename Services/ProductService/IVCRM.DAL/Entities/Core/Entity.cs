namespace IVCRM.DAL.Entities.Core;

public abstract class Entity : IEntity
{
    public long Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;

    public DateTime? Updated { get; set; }
}
