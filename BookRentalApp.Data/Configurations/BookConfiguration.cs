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
            builder.Property(s => s.Translator).IsRequired();
            builder.Property(s => s.Publisher).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Translator).HasMaxLength(100);
            builder.Property(s => s.ISBN).IsRequired().HasMaxLength(15);
            builder.Property(s => s.CategoryId).IsRequired();
            builder.Property(s => s.Price).IsRequired().HasPrecision(10, 2).HasAnnotation("CheckConstraint", new[] { "Price > 0" }); ;
            builder.Property(s => s.IsAvailable).IsRequired();
            builder.Property(s => s.FirstEditionYear).HasMaxLength(4);


        }
    }
}
