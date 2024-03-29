﻿using IVCRM.BLL.Enums;
using IVCRM.BLL.Models;

namespace IVCRM.TestData.Models
{
    public static class TestOrderModels
    {
        public static Order OrderModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        public static OrderDetails OrderDetailsModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
            Customer = TestCustomerModels.CustomerModel,
            OrderItems = TestOrderItemModels.ProductOrderModelCollection

        };

        public static Order UpdatedOrderModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            OrderDate = DateTime.MaxValue,
            CustomerId = 1,
        };

        public static List<Order> OrderModelCollection => new()
        {
            OrderModel,
        };
    }
}
