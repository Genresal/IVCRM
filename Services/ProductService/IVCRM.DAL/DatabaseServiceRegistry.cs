using IVCRM.DAL.DbContexts;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories;
using IVCRM.DAL.Repositories.Customers;
using IVCRM.DAL.Repositories.Orders;
using IVCRM.DAL.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.DAL;

public static class DatabaseServiceRegistry
{
    private const string ConnectionString = "ApplicationDB";

    public static void AddEntityFrameworkSetup(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString);
        services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRepository<Product>, ProductRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
    }
}
