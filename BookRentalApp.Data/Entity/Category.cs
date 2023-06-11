using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRentalApp.Data.Entity
{
    [Table("Categories")]
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> BookList { get; set; }
    }

    public enum Name : byte
    {

        Fiction = 1,
        Non_Fiction,
        Mystery,
        Thriller,
        Romance,
        Science_Fiction,
        Fantasy,
        Historical_Fiction,
        Biography,
        Autobiography,
        Self_Help,
        Poetry,
        Drama,
        Horror,
        Travel,
        Cookbook,
        Art,
        Philosophy,
        History,
        Science

    }
}
