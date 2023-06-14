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
        public string RentalDate { get; set; }
        public byte HowManyDaysToRent { get; set; }
        public string ReturnDate { get; set; }
        public string MustReturnDate { get; set; }

        public void SetRentalDate(DateTime rentalDate)
        {
            RentalDate = rentalDate.ToString("yyyy-MM-dd");
        }

        public void SetReturnDate(DateTime returnDate)
        {
            ReturnDate = returnDate.ToString("yyyy-MM-dd");
        }

        public void SetMustReturnDate(DateTime mustReturnDate)
        {
            MustReturnDate = mustReturnDate.ToString("yyyy-MM-dd");
        }
    }
}

