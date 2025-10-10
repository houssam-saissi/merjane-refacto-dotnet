using Refacto.Dotnet.Controllers.Domain.Base;

namespace Refacto.DotNet.Controllers.Entities
{
    public class Order : BaseEntity<long>
    {
        public ICollection<Product>? Items { get; set; }
    }
}