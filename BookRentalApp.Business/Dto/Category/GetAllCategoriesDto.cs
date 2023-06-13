using BookRentalApp.Business.Dto.Book;
using System.Collections.Generic;

namespace BookRentalApp.Business.Dto.Category
{
    public class GetAllCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GetAllBooksDto> BookList { get; set; }
    }
}
