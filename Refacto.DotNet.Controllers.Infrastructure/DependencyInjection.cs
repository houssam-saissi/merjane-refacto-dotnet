using Microsoft.Extensions.DependencyInjection;
using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Repository;
using Refacto.DotNet.Controllers.Infrastructure.Repository.Product;

namespace Refacto.DotNet.Controllers.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped <IOrderRepository<Order, long>>();
            services.AddScoped <IProductRepository<Product, long>>();
        }
    }
}
