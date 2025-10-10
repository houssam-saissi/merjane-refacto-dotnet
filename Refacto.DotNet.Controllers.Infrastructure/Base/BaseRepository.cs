using Microsoft.EntityFrameworkCore;
using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.DotNet.Controllers.Database.Context;

namespace Refacto.DotNet.Controllers.Infrastructure.Base
{
    public class BaseRepository<TEntity, TType, TContext> : IBaseRepository<TEntity, TType> where TEntity : BaseEntity<TType> where TContext : AppDbContext
    {

        protected readonly TContext _dbContext;

        public BaseRepository(TContext context)
        {
            _dbContext = context;
        }

        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible de récupérer: {ex.Message}");
            }
        }

        public async Task<TEntity> GetById(TType id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible de récupérer: {ex.Message}");
            }
        }

        public async Task SaveData(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
