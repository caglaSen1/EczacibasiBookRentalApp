using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.BookRental
{
    public class UpdateRentedBookDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public byte HowManyDaysToRent { get; set; }

    }
}
