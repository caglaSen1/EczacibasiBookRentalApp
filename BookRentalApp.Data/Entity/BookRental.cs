using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Data.Entity
{
    [Table("BookRentals")]
    public class BookRental : BaseEntity<int>
    {
        
        public Customer Customer { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public Book Book { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }

        public DateTime RentalDate { get; set; }
        public int RentalTerm { get; set; }

        public DateTime? ReturnDate { get; set; } 


    }
}
