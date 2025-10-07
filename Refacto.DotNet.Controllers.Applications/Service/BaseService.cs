using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Applications.Base;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Applications.Service
{
    public class BaseService<TRepository, TEntity> : IBaseService<TEntity>
            where TRepository : IBaseRepository<TEntity>
            where TEntity : BaseEntity
    {

        protected readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }
        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        TEntity IBaseService<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
