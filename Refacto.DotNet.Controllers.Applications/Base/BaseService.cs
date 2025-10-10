using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Applications.Base
{
    public class BaseService<TRepository, TEntity, TType> : IBaseService<TEntity, TType>
            where TRepository : IBaseRepository<TEntity, TType>
            where TEntity : BaseEntity<TType>
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }
    }
}