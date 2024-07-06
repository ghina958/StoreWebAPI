using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        //Primary Key
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();

        // Properties
        builder.Property(o => o.Quantity).IsRequired();
        

        builder.HasOne(o => o.Order)
            .WithMany(n => n.OrderItems)
            .HasForeignKey(o => o.OrderId);


        builder.HasOne(o => o.Product)
              .WithMany(n => n.OrderItems)
              .HasForeignKey(o => o.ProductId);
    }
}
