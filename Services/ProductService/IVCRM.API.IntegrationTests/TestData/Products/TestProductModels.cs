using IVCRM.BLL.Models.Products;

namespace IVCRM.API.IntegrationTests.TestData.Products;

public static class TestProductModels
{
    public static BaseProduct ProductModel => new()
    {
        Name = "Name",
    };

    public static CreateProductRequest CreateProductRequest => new()
    {
        Name = "CreatedName",
        Description = "Desc",
    };

    public static List<BaseProduct> ProductModelCollection => new()
        {
            ProductModel,
        };
}
