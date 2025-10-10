using Refacto.DotNet.Controllers.Applications.Base;
using Refacto.DotNet.Controllers.Entities;

namespace Refacto.DotNet.Controllers.Applications.ServiceProduct
{
    public interface IProductService : IBaseService<Product, long>
    {
        void NotifyDelay(int leadTime, Product p); 
        void HandleSeasonalProduct(Product p);
        void HandleExpiredProduct(Product p);
    }
}