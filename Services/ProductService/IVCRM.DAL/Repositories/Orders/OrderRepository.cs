using AutoMapper;
using IVCRM.DAL.DbContexts;
using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Orders;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
}
