using BookRentalApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRentalApp.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {           
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(300);
        }
    }
}
