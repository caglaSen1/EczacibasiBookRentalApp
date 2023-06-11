using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Business.Dto.Book
{
    public class UpdateBookDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string ISBN { get; set; }

        public int Page { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }
    }
}
