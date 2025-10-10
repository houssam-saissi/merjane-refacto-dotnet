using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refacto.DotNet.Controllers.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refacto.DotNet.Controllers.Infrastructure.Database.Config
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(c => c.Id).HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity).HasName("id");
        }
    }
}