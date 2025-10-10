using Refacto.Dotnet.Controllers.Domain.Base;
using Refacto.Dotnet.Controllers.Domain.Enums;

namespace Refacto.DotNet.Controllers.Entities
{
    public class Product : BaseEntity<long>
    {
        public int LeadTime { get; set; }

        public int Available { get; set; }

        public ProductType Type { get; set; }

        public required string Name { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime SeasonStartDate { get; set; }

        public DateTime SeasonEndDate { get; set; }
    }
}
