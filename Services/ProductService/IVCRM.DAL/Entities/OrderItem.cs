using IVCRM.DAL.Entities.Core;

namespace IVCRM.DAL.Entities;

public class OrderItem : Entity
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    public float Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }


}
