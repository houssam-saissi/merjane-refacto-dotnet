using Refacto.Dotnet.Controllers.Domain.Base;

namespace Refacto.DotNet.Controllers.Infrastructure.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetById(long id);
        List<T> GetAll();
    }
}
