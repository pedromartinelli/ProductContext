using Microsoft.EntityFrameworkCore;
using ProductContext.Domain.Entities;
using ProductContext.Infra.Data.Mappings;

namespace ProductContext.Infra.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}
