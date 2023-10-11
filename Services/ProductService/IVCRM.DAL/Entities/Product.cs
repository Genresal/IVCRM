using IVCRM.DAL.Entities.Core;

namespace IVCRM.DAL.Entities;

public class Product : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    public ICollection<OrderItem>? OrderItems { get; set; }
    public ICollection<Storage>? Storages { get; set; }
}
