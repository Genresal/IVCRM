using IVCRM.DAL.Entities;

namespace IVCRM.TestData.Entities
{
    public static class TestProductEntities
    {
        public static Product Product => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        public static Product UpdatedProduct => new()
        {
            Name = "UpdatedName",
            Price = 2,
            CategoryId = 1,
        };

        public static List<Product> ProductEntityCollection => new ()
        {
            Product,
        };
    }
}
