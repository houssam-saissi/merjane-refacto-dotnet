using Microsoft.Extensions.DependencyInjection;
using Refacto.DotNet.Controllers.Applications.ServiceOrder;
using Refacto.DotNet.Controllers.Applications.ServiceProduct;
using Refacto.DotNet.Controllers.Applications.StrategyProduct;

namespace Refacto.DotNet.Controllers.Applications
{
    public static class DependencyInjection
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ProductStrategyNormal>();
            services.AddScoped<ProductStrategySeasonal>();
            services.AddScoped<ProductStrategyExpirable>();
        }
    }
}
