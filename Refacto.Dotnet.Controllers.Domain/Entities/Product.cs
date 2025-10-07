using Refacto.Dotnet.Controllers.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refacto.DotNet.Controllers.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Column("lead_time")]
        public int LeadTime { get; set; }

        [Column("available")]
        public int Available { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [Column("season_start_date")]
        public DateTime? SeasonStartDate { get; set; }

        [Column("season_end_date")]
        public DateTime? SeasonEndDate { get; set; }
    }
}
