using Microsoft.Extensions.DependencyInjection;
using Refacto.DotNet.Controllers.Infrastructure.Repository;

namespace Refacto.DotNet.Controllers.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<OrderRepository>();
            services.AddScoped<ProductRepository>();
        }
    }
}
