using IVCRM.DAL.Entities.Core;
using IVCRM.DAL.Enums;

namespace IVCRM.DAL.Entities;

public class Order : Entity
{
    public OrderStatus OrderStatus { get; set; }
    public long CustomerId { get; set; }

    public Customer? Customer { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}
