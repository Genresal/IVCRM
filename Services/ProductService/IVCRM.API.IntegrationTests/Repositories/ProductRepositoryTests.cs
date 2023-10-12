using AutoMapper;
using IVCRM.DAL.Repositories.Products;
using IVCRM.TestData.Entities;

namespace IVCRM.API.IntegrationTests.Repositories;

public class ProductRepositoryTests : IntegrationTestsBase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductRepositoryTests()
    {
        _mapper = Factory.Services.GetService(typeof(IMapper)) as IMapper;
        _repository = new ProductRepository(Context, _mapper);
    }

    [Fact]
    public async Task Create_Entity_ReturnsEntity()
    {
        var entity = TestProductEntities.Product;

        var actualResult = await _repository.AddAsync(entity);

        actualResult.ShouldBeEquivalentTo(entity);
        Context.Products.Last().ShouldBeEquivalentTo(entity);
    }
}
