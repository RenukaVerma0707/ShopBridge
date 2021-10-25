using Microsoft.EntityFrameworkCore;
using ShopBridge.Infrastrusture.Models;

namespace ShopBridge.Infrastrusture
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Products> Products { get; set; }
    }

}
