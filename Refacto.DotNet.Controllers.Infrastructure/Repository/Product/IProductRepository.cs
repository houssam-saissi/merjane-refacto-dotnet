using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Infrastructure.Repository.Product
{
    public interface IProductRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : BaseEntity<TType>
    {
    }
}