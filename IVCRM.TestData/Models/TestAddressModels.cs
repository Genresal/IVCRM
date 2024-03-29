﻿using IVCRM.BLL.Models;

namespace IVCRM.TestData.Models
{
    public static class TestAddressModels
    {
        public static Address AddressModel => new()
        {
            Id = 1,
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };

        public static List<Address> AddressModelCollection => new ()
        {
            AddressModel,
        };
    }
}
