using Refacto.Dotnet.Controllers.Domain.Enums;
using Refacto.DotNet.Controllers.Applications.ServiceProduct;
using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Repository.Product;

namespace Refacto.DotNet.Controllers.Applications.StrategyProduct
{
    public class ProductStrategyExpirable : IStrategyProduct
    {
        private readonly ProductService _ps;
        private readonly IProductRepository<Product, long> _pr;

        public ProductStrategyExpirable(ProductService productService, IProductRepository<Product, long> productRepository)
        {
            _ps = productService;
            _pr = productRepository;
        }

        public bool CanProcess(Product product)
        {
            return product.Type == ProductType.EXPIRABLE;
        }

        public void Execute(Product product)
        {
            if (product.Available > 0 && product.ExpiryDate > DateTime.Now.Date)
            {
                product.Available -= 1;
                _pr.SaveData(product);
                return;
            }
            _ps.HandleExpiredProduct(product);
        }
    }
}