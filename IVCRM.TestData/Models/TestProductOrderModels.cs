using IVCRM.BLL.Models;

namespace IVCRM.TestData.Models
{
    public static class TestProductOrderModels
    {
        public static ProductOrder ProductOrderModel => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestProductModels.ProductModel,
        };

        public static List<ProductOrder> ProductOrderModelCollection => new()
        {
            ProductOrderModel,
        };
    }
}
