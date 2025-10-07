
using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Applications.Service
{
    public class OrderService : BaseService<IOrderRepository, Order>
    {
        public OrderService(IOrderRepository repository) : base(repository)
        {
        }
    }
}
