using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refacto.DotNet.Controllers.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refacto.DotNet.Controllers.Infrastructure.Database.Config
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(c => c.Id).HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity).HasName("id");
            builder.Property(c => c.Name).HasColumnName("name");
            builder.Property(c => c.SeasonStartDate).HasColumnName("season_start_date");
            // même traitement pour renommer les autres propriétés si nécessaire
        }
    }
}