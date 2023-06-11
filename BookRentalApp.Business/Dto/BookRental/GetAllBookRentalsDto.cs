using System;

namespace BookRentalApp.Business.Dto.BookRental
{
    public class GetAllBookRentalsDto
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }

        public DateTime RentalDate { get; set; }
        public int RentalTerm { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsRented { get; set; }
    }
}
