using BookRentalApp.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRentalApp.Data.Configurations
{
    public class RentedBookConfiguration
    {
        public void Configure(EntityTypeBuilder<RentedBook> builder)
        {
            builder.Property(s => s.CustomerId).IsRequired();
            builder.Property(s => s.BookId).IsRequired();
            builder.Property(s => s.RentalDate).IsRequired();
            builder.Property(s => s.HowManyDaysToRent).IsRequired();
            builder.Property(s => s.MustReturnDate).IsRequired();


        }


    }
}