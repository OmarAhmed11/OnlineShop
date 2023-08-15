using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;

namespace OnlineShop.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
