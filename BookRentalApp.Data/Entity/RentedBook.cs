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

        public DateTime RentalDate { get; set; } = DateTime.Today;
        public byte HowManyDaysToRent { get; set; }

        public DateTime ReturnDate { get; set; }

        private DateTime _mustReturnDate;

        public DateTime MustReturnDate
        {
            get => _mustReturnDate;
            set
            {
                _mustReturnDate = RentalDate.AddDays(HowManyDaysToRent);
            }
        }
         
        
    }

    
}
