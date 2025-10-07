using Microsoft.EntityFrameworkCore;
using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Database.Context;
using Refacto.DotNet.Controllers.Infrastructure.Base;

namespace Refacto.DotNet.Controllers.Infrastructure.Repository
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
            where TEntity : BaseEntity
            where TContext : AppDbContext
    {
        protected readonly TContext _dbContext;

        public BaseRepository(TContext context)
        {
            _dbContext = context;
        }

        public TEntity GetById(long id)
        {
            try
            {
                return _dbContext.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible de récupérer: {ex.Message}");
            }
        }

        public List<TEntity> GetAll()
        {
            try
            {
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible de récupérer: {ex.Message}");
            }
        }

    }
}
