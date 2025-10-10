using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Database.Context;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Infrastructure.Repository.Product
{
    public class ProductRepository<TEntity, TType> : BaseRepository<TEntity, TType, AppDbContext> where TEntity : BaseEntity<TType>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
