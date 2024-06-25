using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Primary Key
            builder.HasKey(n => n.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(n => n.Name).IsRequired().HasMaxLength(50);
            builder.Property(n => n.Price).IsRequired();

            builder.HasOne(n => n.Store)
                .WithMany(s => s.Products)
                .HasForeignKey(n => n.StoreId);

            builder.HasMany(n => n.OrderItems)
                  .WithOne(m => m.Product)
                  .HasForeignKey(m => m.ProductId);

        }
    }
}
