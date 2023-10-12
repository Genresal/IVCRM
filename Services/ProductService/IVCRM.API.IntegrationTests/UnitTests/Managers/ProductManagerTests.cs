using AutoMapper;
using IVCRM.API.IntegrationTests.TestData.Products;
using IVCRM.BLL.Managers;
using IVCRM.BLL.Models.Products;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Products;
using IVCRM.TestData.Entities;
using Moq;
using Moq.AutoMock;

namespace IVCRM.API.IntegrationTests.UnitTests.Managers;

public class ProductManagerTests
{
    [Fact]
    public async Task Create_Model_ReturnsModel()
    {
        var model = TestProductModels.ProductModel;
        var entity = TestProductEntities.Product;

        var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
        mocker.Setup<IProductRepository, Task<Product>>(x => x.AddAsync(It.IsAny<Product>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);
        mocker.Setup<IMapper, BaseProduct>(x => x.Map<BaseProduct>(entity)).Returns(model);

        var service = mocker.CreateInstance<Manager<BaseProduct, Product>>();

        var response = await service.CreateAsync(model, CancellationToken.None);

        mocker.GetMock<IProductRepository>().Verify(x => x.AddAsync(It.IsAny<Product>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()), Times.Once);
        response.ShouldBeEquivalentTo(model);
    }
}
