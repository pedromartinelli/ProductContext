using Microsoft.EntityFrameworkCore;
using ProductContext.Domain.Entities;

namespace ProductContext.Infra.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base() { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Product;User ID=sa;Password=1q2w3e!@#;TrustServerCertificate=True");
        }
    }
}
