using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataAccess.Configuration
{
    public class StoreConfiguration: IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            //Primary Key
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(s => s.name).IsRequired();
            builder.Property(s => s.Address).IsRequired();

            builder.Property(x => x.WorkingHours).HasColumnType("jsonb");

            // Relationship with one category
            builder.HasOne(s => s.Category)
                .WithMany(c => c.Stores)
                .HasForeignKey(s => s.CategoryId);


            builder.HasMany(s => s.Products)
                   .WithOne(p => p.Store)
                   .HasForeignKey(p => p.StoreId);
        }
    }
    
}
