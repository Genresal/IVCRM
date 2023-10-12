using IVCRM.DAL.Entities.Core;

namespace IVCRM.DAL.Entities;

public class Storage : Entity
{
    public float Quantity { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
