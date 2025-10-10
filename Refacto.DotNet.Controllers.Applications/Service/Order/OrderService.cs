using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Repository;

namespace Refacto.DotNet.Controllers.Applications.ServiceOrder
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository<Order, long> _pr;

        public OrderService(IOrderRepository<Order, long> orderRepository) : base()
        {
            _pr = orderRepository;
        }

        public async Task<Order> GetByIdAsync(long id)
        {
            return await _pr.GetById(id);
        }
    }
}