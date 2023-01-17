using IVCRM.API.ViewModels;

namespace IVCRM.TestData.ViewModels
{
    internal static class TestOrderItemViewModels
    {
        internal static OrderItemViewModel OrderItemViewModel => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestOrderItemModels.ValidProductViewModel,
        };

        internal static List<OrderItemViewModel> ProductOrderViewModelCollection => new()
        {
            OrderItemViewModel,
        };
    }
}
