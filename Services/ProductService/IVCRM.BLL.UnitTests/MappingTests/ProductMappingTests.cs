using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.TestData.Entities;
using IVCRM.TestData.Models;
using IVCRM.TestData.ViewModels;
using IVCRM.DAL.Entities;
using TestOrderItemModels = IVCRM.TestData.ViewModels.TestOrderItemModels;

namespace IVCRM.BLL.UnitTests.MappingTests
{
    public class ProductMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Product>(entity);

            //Assert
            result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsEntity()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<ProductEntity>(model);

            //Assert
            result.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public void Map_Model_ReturnsViewModel()
        {
            //Arrange 
            var model = TestProductModels.ProductModel;
            var viewModel = TestOrderItemModels.ValidProductViewModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<ProductViewModel>(model);

            //Assert 
            result.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public void Map_ChangeViewModel_ReturnsModel()
        {
            //Arrange 
            var viewModel = TestOrderItemModels.ValidChangeProductViewModel;
            var model = TestProductModels.ProductModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<Product>(viewModel);
            result.Id = model.Id;

            //Assert 
            result.ShouldBeEquivalentTo(model);

        }
    }
}