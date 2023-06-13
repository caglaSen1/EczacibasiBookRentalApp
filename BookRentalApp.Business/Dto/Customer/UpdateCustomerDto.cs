using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.Customer
{
    public class UpdateCustomerDto
    {
        
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }
                
        [MaxLength(11)]
        public string Phone { get; set; }
                
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
