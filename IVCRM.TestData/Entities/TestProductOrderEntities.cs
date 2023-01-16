using IVCRM.DAL.Entities;

namespace IVCRM.TestData.Entities
{
    public static class TestProductOrderEntities
    {
        public static ProductOrderEntity ProductOrderEntity => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestProductEntities.ProductEntity,
        };

        public static List<ProductOrderEntity> ProductOrderEntityCollection => new()
        {
            ProductOrderEntity,
        };
    }
}
