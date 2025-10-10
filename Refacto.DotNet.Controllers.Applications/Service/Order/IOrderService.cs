using Refacto.DotNet.Controllers.Applications.Base;
using Refacto.DotNet.Controllers.Entities;

namespace Refacto.DotNet.Controllers.Applications.ServiceOrder
{
    public interface IOrderService : IBaseService<Order, long>
    {
        Task<Order> GetByIdAsync(long id);
    }
}