using IVCRM.DAL.Entities;

namespace IVCRM.TestData.Entities
{
    public static class TestAddressEntities
    {
        public static AddressEntity AddressEntity => new()
        {
            Id = 1,
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };

        public static List<AddressEntity> AddressEntityCollection => new ()
        {
            AddressEntity,
        };
    }
}
