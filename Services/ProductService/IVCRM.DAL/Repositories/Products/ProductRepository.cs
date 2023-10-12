using AutoMapper;
using IVCRM.DAL.DbContexts;
using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Products;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
}
