using IVCRM.DAL.Entities;

namespace IVCRM.TestData.Entities
{
    public static class TestOrderItemEntities
    {
        public static OrderItemEntity OrderItemEntity => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestProductEntities.ProductEntity,
        };

        public static List<OrderItemEntity> ProductOrderEntityCollection => new()
        {
            OrderItemEntity,
        };
    }
}
