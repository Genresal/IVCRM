using FakeItEasy;
using IVCRM.BLL.Services;
using IVCRM.DAL.DbContexts;
using IVCRM.DAL.Entities.Core;
using MassTransit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.API.IntegrationTests.Infrastructure;

public interface ISecondBus :
        IBus
{
}

public class IntegrationTestsBase : IDisposable
{
    public IntegrationTestsBase()
    {
        Factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            builder.ConfigureServices(services =>
            {
                var dbContextService = services.SingleOrDefault(x =>
                    x.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                services.Remove(dbContextService!);

                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TestDb"));

                services.AddMassTransitTestHarness(x =>
                {
                    x.UsingInMemory();
                });

                services.AddScoped(serviceProvider => A.Fake<AzurePictureService>());
            }));
        Server = Factory.Server;
        Client = Server.CreateClient();
        Context = Factory.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>()!;
    }

    protected TestServer Server { get; }
    protected HttpClient Client { get; }
    protected ApplicationDbContext Context { get; }
    protected WebApplicationFactory<Program> Factory { get; }


    public async Task<long> AddToContext<T>(T entity) where T : Entity
    {
        var dbSet = Context.Set<T>();
        await dbSet.AddAsync(entity);
        await Context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task AddRangeToContext<T>(IEnumerable<T> entities) where T : class, IEntity
    {
        var dbSet = Context.Set<T>();
        await dbSet.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
