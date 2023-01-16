using IVCRM.API.ViewModels;

namespace IVCRM.TestData.ViewModels
{
    public static class TestAddressViewModels
    {
        public static AddressViewModel ValidAddressViewModel => new()
        {
            Id = 1,
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };

        public static ChangeAddressViewModel ValidChangeAddressViewModel => new()
        {
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };
    }
}
