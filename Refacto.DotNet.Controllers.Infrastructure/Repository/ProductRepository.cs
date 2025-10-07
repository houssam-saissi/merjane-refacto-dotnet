using Microsoft.EntityFrameworkCore;
using Refacto.DotNet.Controllers.Database.Context;
using Refacto.DotNet.Controllers.Entities;

namespace Refacto.DotNet.Controllers.Infrastructure.Repository
{
    internal class ProductRepository : BaseRepository<Product, AppDbContext>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
