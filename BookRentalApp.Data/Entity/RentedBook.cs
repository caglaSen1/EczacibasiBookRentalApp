using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRentalApp.Data.Entity
{
    [Table("RentedBooks")]
    public class RentedBook : BaseEntity<int>
    {        
        public Customer Customer { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public Book Book { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
                
        public DateTime? ReturnDate = null;
                
        public DateTime RentalDate { get; set; } = DateTime.Now.Date;

        public byte HowManyDaysToRent { get; set; } = 0;

        public DateTime MustReturnDate { get; set; }
                
    }

}
