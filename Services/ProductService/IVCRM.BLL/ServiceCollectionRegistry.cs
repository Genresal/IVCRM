using IVCRM.BLL.Managers;
using IVCRM.BLL.Models.Products;
using IVCRM.BLL.Services;
using IVCRM.DAL;
using IVCRM.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.BLL
{
    public static class ServiceCollectionRegistry
    {
        private const string AzureConnectionString = "AzureBlobStorage";
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var azureConnectionString = configuration.GetConnectionString(AzureConnectionString);

            services.AddEntityFrameworkSetup(configuration);
            services.AddRepositories();

            services.AddTransient<IManager<BaseProduct>, Manager<BaseProduct, Product>>();

            services.AddTransient<AzurePictureService>(x => new AzurePictureService(azureConnectionString));
        }
    }
}
