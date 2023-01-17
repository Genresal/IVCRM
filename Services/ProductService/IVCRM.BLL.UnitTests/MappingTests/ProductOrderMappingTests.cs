using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.TestData.Entities;
using IVCRM.TestData.ViewModels;
using IVCRM.TestData.Models;

namespace IVCRM.BLL.UnitTests.MappingTests
{
    public class ProductOrderMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestData.Models.TestOrderItemModels.OrderItemModel;
            var entity = TestOrderItemEntities.OrderItemEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<OrderItem>(entity);

            //Assert
            result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsViewModel()
        {
            //Arrange 
            var model = TestProductModels.ProductModel;
            var viewModel = TestProductViewModels.ValidProductViewModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<ProductViewModel>(model);

            //Assert 
            result.ShouldBeEquivalentTo(viewModel);
        }
    }
}