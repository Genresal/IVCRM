using IVCRM.API.IntegrationTests.TestData.Products;
using IVCRM.BLL.Models.Products;
using IVCRM.TestData.Entities;
using System.Net;

namespace IVCRM.API.IntegrationTests.ApiTests;

public class ProductControllerTests : IntegrationTestsBase
{
    [Fact]
    public async Task CreateProduct_ValidInput_ReturnsOk()
    {
        var entity = TestProductEntities.Product;

        using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/product");
        request.AddContent(TestProductModels.CreateProductRequest);

        var actualResult = await Client.SendAsync(request);
        var responseResult = actualResult.GetResponseResult<ProductResponse>();

        entity.Id = responseResult.Id;

        actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
        Context.Products.Last().ShouldBeEquivalentTo(entity);
    }

    [Fact]
    public async Task CreateProduct_InvalidInput_ReturnsBadRequest()
    {
        var unchangedCollectionCount = Context.Products.Count();

        using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/product");
        request.AddContent(new CreateProductRequest());

        var actualResult = await Client.SendAsync(request);

        actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        Context.Products.Count().ShouldBe(unchangedCollectionCount);
    }
}
