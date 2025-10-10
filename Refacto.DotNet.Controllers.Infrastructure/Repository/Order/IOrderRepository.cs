using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Infrastructure.Repository
{
    public interface IOrderRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : BaseEntity<TType>
    {
        Task<Order> FilterItem(TType orderId);
    }
}