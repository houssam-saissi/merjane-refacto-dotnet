using Refacto.Dotnet.Controllers.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refacto.DotNet.Controllers.Entities
{
    [Table("orders")]
    public class Order : BaseEntity
    {
        public ICollection<Product>? Items { get; set; }
    }
}
