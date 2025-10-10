using Refacto.Dotnet.Controllers.Domain.Enums;
using Refacto.DotNet.Controllers.Applications.Service.Notification;
using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Repository.Product;

namespace Refacto.DotNet.Controllers.Applications.StrategyProduct
{
    public class ProductStrategyNormal : IStrategyProduct
    {
        private readonly INotificationService _ns;
        private readonly IProductRepository<Product, long> _pr;

        public ProductStrategyNormal(IProductRepository<Product, long> productRepository, INotificationService ns)
        {
            _pr = productRepository;
            _ns = ns;
        }

        public bool CanProcess(Product product)
        {
            return product.Type == ProductType.NORMAL;
        }

        public void Execute(Product product)
        {
            if (product.Available > 0)
            {
                product.Available -= 1;
                _pr.SaveData(product);
                return;
            }
            int leadTime = product.LeadTime;
            if (leadTime > 0)
            {
                _ns.SendDelayNotification(leadTime, product.Name);
            }
        }
    }
}
