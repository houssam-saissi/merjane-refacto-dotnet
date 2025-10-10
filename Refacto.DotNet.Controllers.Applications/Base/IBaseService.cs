using Refacto.Dotnet.Controllers.Domain.Base;

namespace Refacto.DotNet.Controllers.Applications.Base
{
    public interface IBaseService<TEntity, TType> where TEntity : BaseEntity<TType>
    {
    }
}