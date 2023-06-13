using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.Customer
{
    public class CreateCustomerDto
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
        [MaxLength(11, ErrorMessage = "Phone must be at most 11 digit long")]
        [MinLength(4, ErrorMessage = "Phone must be at least 11 digit long")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
    }
}
