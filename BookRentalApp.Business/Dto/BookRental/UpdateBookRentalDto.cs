using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Business.Dto.BookRental
{
    public class UpdateBookRentalDto
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int RentalTerm { get; set; }
        
    }
}
