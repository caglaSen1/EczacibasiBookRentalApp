using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookRentalApp.Data.Entity;

namespace BookRentalApp.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder) 
        {
            
            builder.Property(s => s.Title).IsRequired().HasMaxLength(250);
            builder.Property(s => s.Author).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Publisher).HasMaxLength(100);
            builder.Property(s => s.Price).IsRequired();
            builder.Property(s => s.Category).IsRequired();
            builder.Property(s => s.IsAvailable).IsRequired();
            builder.Property(s => s.Price).HasPrecision(10, 2).HasAnnotation("CheckConstraint", new[] { "Price > 0" }); ;
        }
    }
}
