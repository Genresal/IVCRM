using IVCRM.BLL.Models;

namespace IVCRM.TestData.Models
{
    public static class TestOrderItemModels
    {
        public static OrderItem OrderItemModel => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestProductModels.ProductModel,
        };

        public static List<OrderItem> ProductOrderModelCollection => new()
        {
            OrderItemModel,
        };
    }
}
