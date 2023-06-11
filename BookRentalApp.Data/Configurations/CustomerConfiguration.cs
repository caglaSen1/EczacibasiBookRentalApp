using BookRentalApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRentalApp.Data.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.Phone).IsRequired().HasMaxLength(11);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);

        }
    }
}
