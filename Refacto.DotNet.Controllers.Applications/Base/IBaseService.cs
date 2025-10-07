using Refacto.Dotnet.Controllers.Domain.Base;
using System.Linq.Expressions;

namespace Refacto.DotNet.Controllers.Applications.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T GetById(long id);
        T GetAll();
    }
}
