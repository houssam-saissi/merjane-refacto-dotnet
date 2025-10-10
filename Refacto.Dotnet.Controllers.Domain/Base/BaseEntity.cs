namespace Refacto.Dotnet.Controllers.Domain.Base
{
    public abstract class BaseEntity<T>
    {
        public required T Id { get; set; }
    }
}
