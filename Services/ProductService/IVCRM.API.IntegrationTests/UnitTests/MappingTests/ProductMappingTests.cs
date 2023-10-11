using AutoMapper;
using IVCRM.API.IntegrationTests.TestData.Products;
using IVCRM.BLL.AutoMapper;
using IVCRM.DAL.Entities;
using IVCRM.TestData.Entities;

namespace IVCRM.API.IntegrationTests.UnitTests.MappingTests;
public class ProductMappingTests
{
    [Fact]
    public void Map_Entity_ReturnsModel()
    {
        var model = TestProductModels.ProductModel;
        var entity = TestProductEntities.Product;

        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        var mapper = config.CreateMapper();

        var result = mapper.Map<Product>(entity);

        result.ShouldBeEquivalentTo(model);
    }

    [Fact]
    public void Map_Model_ReturnsEntity()
    {
        var model = TestProductModels.ProductModel;
        var entity = TestProductEntities.Product;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        var mapper = config.CreateMapper();

        var result = mapper.Map<Product>(model);

        result.ShouldBeEquivalentTo(entity);
    }
}
