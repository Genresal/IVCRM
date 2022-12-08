﻿using IVCRM.API.ViewModels;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
{
    internal static class TestCustomerViewModels
    {
        internal static CustomerViewModel ValidCustomerViewModel => new()
        {
            Id = 1,
            FullName = "FirstName LastName",
            PhoneNumber = "+1234567",
        };

        internal static ChangeCustomerViewModel ValidChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "+1234567",
        };
    }
}