using System;
using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.BookRental
{
    public class CreateRentedBookDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public byte HowManyDaysToRent { get; set; }
    }
}
