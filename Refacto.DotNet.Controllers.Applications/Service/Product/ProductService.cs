using Refacto.DotNet.Controllers.Applications.Service.Notification;
using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Repository.Product;

namespace Refacto.DotNet.Controllers.Applications.ServiceProduct
{
    public class ProductService : IProductService
    {
        private readonly INotificationService _ns;
        private readonly IProductRepository<Product, long> _pr;

        public ProductService(IProductRepository<Product, long> repository, INotificationService ns) : base()
        {
            _pr = repository;
            _ns = ns;
        }

        public void NotifyDelay(int leadTime, Product p)
        {
            p.LeadTime = leadTime;

            _pr.SaveData(p);
            _ns.SendDelayNotification(leadTime, p.Name);
        }

        public void HandleSeasonalProduct(Product p)
        {
            if(!(DateTime.Now.AddDays(p.LeadTime) > p.SeasonEndDate) && !(p.SeasonStartDate > DateTime.Now))
            {
                NotifyDelay(p.LeadTime, p);
                return;
            }
            if (DateTime.Now.AddDays(p.LeadTime) > p.SeasonEndDate)
            {
                p.Available = 0;
            }
            _ns.SendOutOfStockNotification(p.Name);
            _pr.SaveData(p);
        }

        public void HandleExpiredProduct(Product p)
        {
            if (p.Available > 0 && p.ExpiryDate > DateTime.Now)
            {
                p.Available -= 1;
            }
            else
            {
                p.Available = 0;
                _ns.SendExpirationNotification(p.Name, p.ExpiryDate);
            }
            _pr.SaveData(p);
        }
    }
}
