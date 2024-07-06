using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using Domain.Store;

namespace DataAccess.Configuration;

public class StoreConfiguration: IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        //Primary Key
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();

        // Properties
        builder.Property(s => s.Name).IsRequired();
        builder.Property(s => s.Address).IsRequired();

        //builder.Property(x => x.WorkingHours).HasColumnType("jsonb");

        builder.Property(x => x.WorkingHours)
        .HasConversion(
            v => System.Text.Json.JsonSerializer.Serialize(v, new JsonSerializerOptions { WriteIndented = true }),
            v => System.Text.Json.JsonSerializer.Deserialize<List<WorkingHours>>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
        )
        .HasColumnType("jsonb"); // For PostgreSQL JSONB type

        // Relationship with one category
        builder.HasOne(s => s.Category)
            .WithMany(c => c.Stores)
            .HasForeignKey(s => s.CategoryId);


        builder.HasMany(s => s.Products)
               .WithOne(p => p.Store)
               .HasForeignKey(p => p.StoreId);
    }
}

