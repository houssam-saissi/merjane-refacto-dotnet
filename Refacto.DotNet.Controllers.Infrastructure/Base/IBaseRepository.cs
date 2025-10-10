using Refacto.Dotnet.Controllers.Domain.Base;

namespace Refacto.DotNet.Controllers.Infrastructure.Base
{
    public interface IBaseRepository<TEntity, TType> where TEntity : BaseEntity<TType>
    {
        Task<TEntity> GetById(TType id);
        Task<List<TEntity>> GetAll();
        Task SaveData(TEntity entity);
    }
}
