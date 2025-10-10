using Microsoft.AspNetCore.Mvc;
using Refacto.DotNet.Controllers.Applications.ServiceOrder;
using Refacto.DotNet.Controllers.Applications.StrategyProduct;
using Refacto.DotNet.Controllers.Dtos.Product;
using Refacto.DotNet.Controllers.Entities;

namespace Refacto.DotNet.Controllers.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private IOrderService _iOService;
        private IEnumerable<IStrategyProduct> _strategies;

        public OrdersController(IEnumerable<IStrategyProduct> strategies, IOrderService orderService)
        {
            _strategies = strategies; 
            _iOService = orderService;
        }

        [HttpPost("{orderId}/processOrder")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ProcessOrderResponse>> ProcessOrder(long orderId)
        {
            Order? order = await _iOService.GetByIdAsync(orderId);

            if (order != null)
            {
                List<long> ids = new() { orderId };
                ICollection<Product>? products = order.Items;

                if (products != null && products.Count > 0)
                {
                    foreach (Product p in products)
                    {
                        var prd_strategy = _strategies.FirstOrDefault(_strategies => _strategies.CanProcess(p));

                        if (prd_strategy != null)
                        {
                            prd_strategy.Execute(p);
                        }
                        else
                        {
                            throw new NotImplementedException($"No strategy found for product type {p.Type}");
                        }
                    }
                }

                return new ProcessOrderResponse(order.Id);
            }

            return NotFound();
           
        }
    }
}
