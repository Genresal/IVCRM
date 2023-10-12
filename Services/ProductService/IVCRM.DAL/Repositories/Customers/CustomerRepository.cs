using AutoMapper;
using IVCRM.DAL.DbContexts;
using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Customers;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
}
