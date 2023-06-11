using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Business.Dto.BookRental
{
    public class CreateBookRentalDto
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }

        public DateTime RentalDate { get; set; }
        public int RentalTerm { get; set; }
    }
}
