using Microsoft.Extensions.DependencyInjection;
using Refacto.DotNet.Controllers.Applications.Service;

namespace Refacto.DotNet.Controllers.Applications
{
    public static class DependencyInjection
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<OrderService>();
            services.AddScoped<ProductService>();
        }
    }
}
