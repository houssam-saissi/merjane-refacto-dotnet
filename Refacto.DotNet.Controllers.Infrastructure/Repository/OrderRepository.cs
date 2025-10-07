using Microsoft.EntityFrameworkCore;
using Refacto.DotNet.Controllers.Database.Context;
using Refacto.DotNet.Controllers.Entities;

namespace Refacto.DotNet.Controllers.Infrastructure.Repository
{
    internal class OrderRepository : BaseRepository<Order, AppDbContext>
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        /*public Order GetById(long orderId)
        {
            return _dbContext.Orders.Include(o => o.Items)
                .SingleOrDefault(o => o.Id == orderId);
        }*/
    }
}
