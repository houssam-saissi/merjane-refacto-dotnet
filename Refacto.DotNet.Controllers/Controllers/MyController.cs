using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Refacto.DotNet.Controllers.Applications.Service;
using Refacto.DotNet.Controllers.Database.Context;
using Refacto.DotNet.Controllers.Dtos.Product;
using Refacto.DotNet.Controllers.Services.Impl;
using ProductService = Refacto.DotNet.Controllers.Applications.Service.ProductService;

namespace Refacto.DotNet.Controllers.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private OrderService _orderService;
        private ProductService _productService;

        //private readonly ProductService _ps;
        private readonly AppDbContext _ctx;

        public OrdersController(OrderService orderService, ProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        [HttpPost("{orderId}/processOrder")]
        [ProducesResponseType(200)]
        public ActionResult<ProcessOrderResponse> ProcessOrder(long orderId)
        {

            Entities.Order? order = _orderService.GetById(orderId); 
           
            
            /*_ctx.Orders
               
            Console.WriteLine(order);*/

            List<long> ids = new() { orderId };
            ICollection<Entities.Product>? products = order.Items;

            /* Ce code brise le O du SOLID (Recommandations possibles:
             *      - Utiliser une énumértation pour les types de produits
             *      - Extraire la logique de traitement des produits dans des classes dédiées
             *      - Utiliser des interfaces pour définir des comportements communs au lieu d'une instance d'objet
             */
            foreach (Entities.Product p in products)
            {
                if (p.Type == "NORMAL")
                {
                    if (p.Available > 0)
                    {
                        p.Available -= 1;
                        _ctx.Entry(p).State = EntityState.Modified;
                        _ = _ctx.SaveChanges();

                    }
                    else
                    {
                        int leadTime = p.LeadTime;
                        if (leadTime > 0)
                        {
                            _productService.NotifyDelay(leadTime, p);
                        }
                    }
                }
                else if (p.Type == "SEASONAL")
                {
                    if (DateTime.Now.Date > p.SeasonStartDate && DateTime.Now.Date < p.SeasonEndDate && p.Available > 0)
                    {
                        p.Available -= 1;
                        _ = _ctx.SaveChanges();
                    }
                    else
                    {
                        _productService.HandleSeasonalProduct(p);
                    }
                }
                else if (p.Type == "EXPIRABLE")
                {
                    if (p.Available > 0 && p.ExpiryDate > DateTime.Now.Date)
                    {
                        p.Available -= 1;
                        _ = _ctx.SaveChanges();
                    }
                    else
                    {
                        _productService.HandleExpiredProduct(p);
                    }
                }
            }

            return new ProcessOrderResponse(order.Id);
        }
    }
}
