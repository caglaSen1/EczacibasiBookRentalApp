using BookRentalApp.Data.Entity;
using System;
namespace BookRentalApp.Business.Dto.BookRental
{
    public class GetRentedBookByIdDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime RentalDate { get; set; }
        public byte HowManyDaysToRent { get; set; }
        public DateTime ReturnDate { get; set; } 
        public DateTime MustReturnDate { get; set; }
    }
}

