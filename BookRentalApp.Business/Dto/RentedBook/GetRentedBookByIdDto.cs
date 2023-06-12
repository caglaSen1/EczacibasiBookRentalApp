using System;
namespace BookRentalApp.Business.Dto.BookRental
{
    public class GetRentedBookByIdDto
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime RentalDate { get; set; }
        public byte HowManyDaysToRent { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsRented { get; set; }
    }
}
