using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.Customer
{
    public class UpdateCustomerDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
