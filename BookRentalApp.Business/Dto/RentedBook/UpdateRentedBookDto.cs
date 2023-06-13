using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.BookRental
{
    public class UpdateRentedBookDto
    {
        public int CustomerId { get; set; }               
        public int BookId { get; set; }        
        public byte HowManyDaysToRent { get; set; }

    }
}
