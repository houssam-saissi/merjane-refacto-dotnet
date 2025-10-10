using Refacto.Dotnet.Controllers.Domain.Enums;
using Refacto.DotNet.Controllers.Applications.ServiceProduct;
using Refacto.DotNet.Controllers.Entities;
using Refacto.DotNet.Controllers.Infrastructure.Repository.Product;

namespace Refacto.DotNet.Controllers.Applications.StrategyProduct
{
    public class ProductStrategySeasonal : IStrategyProduct
    {
        private readonly ProductService _ps;
        private readonly IProductRepository<Product, long> _pr;

        public ProductStrategySeasonal(ProductService productService, IProductRepository<Product, long> productRepository)
        {
            _ps = productService;
            _pr = productRepository;
        }

        public bool CanProcess(Product product)
        {
            return product.Type == ProductType.SEASONAL;
        }

        public void Execute(Product product)
        {
            if (DateTime.Now.Date > product.SeasonStartDate && DateTime.Now.Date < product.SeasonEndDate && product.Available > 0)
            {
                product.Available -= 1;
                _pr.SaveData(product);
                return;
            }
            _ps.HandleSeasonalProduct(product);
        }
    }
}