using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.phone).IsRequired();
            builder.Property(s => s.Password).IsRequired();
            builder.Property(s => s.Gender).HasDefaultValue(Gender.Other);
            builder.HasDiscriminator(x => x.Role)
                .HasValue<Admin>(Domain.Enums.Role.Admin)
                .HasValue<Customer>(Domain.Enums.Role.Customer);
        }
    }
}
