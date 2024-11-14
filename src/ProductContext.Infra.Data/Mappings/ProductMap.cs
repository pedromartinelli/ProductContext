using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductContext.Domain.Entities;

namespace ProductContext.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            //builder.Property(x => x.Id)
            //    .HasColumnName("Id")
            //    .HasColumnType("uniqueidentifier");

            //builder.Property(x => x.Name)
            //     .IsRequired()
            //     .HasColumnName("Name")
            //     .HasColumnType("varchar")
            //     .HasMaxLength(100);

            //builder.Property(x => x.Description)
            //    .IsRequired()
            //    .HasColumnName("Description")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(200);

            //builder.Property(x => x.Price)
            //    .IsRequired()
            //    .HasColumnName("Price")
            //    .HasColumnType("decimal(18,2)");

            //builder.Property(x => x.Quantity)
            //    .IsRequired()
            //    .HasColumnName("Quantity")
            //    .HasColumnType("int");

            //builder.Property(x => x.IsActive)
            //    .IsRequired()
            //    .HasColumnName("IsActive")
            //    .HasColumnType("bit");

            //builder.Property(x => x.CreateDate)
            //    .IsRequired()
            //    .HasColumnName("CreateDate")
            //    .HasColumnType("datetime");

            //builder.Property(x => x.LastUpdateDate)
            //    .IsRequired()
            //    .HasColumnName("LastUpdateDate")
            //    .HasColumnType("datetime");
        }
    }
}
