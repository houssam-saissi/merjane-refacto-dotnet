using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Database.Context;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Infrastructure.Repository
{
    public class OrderRepository<TEntity, TType> : BaseRepository<TEntity, TType, AppDbContext> where TEntity : BaseEntity<TType>
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