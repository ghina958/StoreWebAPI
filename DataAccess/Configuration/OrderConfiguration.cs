using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;

namespace DataAccess.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        //Primary Key
        builder.HasKey(o=> o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();

        // Properties
        builder.Property(o => o.No).IsRequired();
        builder.Property(o => o.Date).IsRequired();
        builder.Property(o => o.OrderStatus).HasDefaultValue(OrderStatus.AwaitingPickUp);


        // Relationship with one category
        builder.HasOne(o => o.Customer)
            .WithMany(n => n.Orders)
            .HasForeignKey(o => o.CustomerId);

       
        builder.HasMany(c => c.OrderItems)
               .WithOne(s => s.Order)
               .HasForeignKey(s => s.OrderId);
    }
}
