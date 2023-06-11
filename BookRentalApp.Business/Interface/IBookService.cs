using BookRentalApp.Business.Dto.Book;
using System.Collections.Generic;


namespace BookRentalApp.Business.Interface
{
    public interface IBookService
    {
        void Add(CreateBookDto book);
        void Delete(int id);
        ServiceResult<GetBookByIdDto> Update(int id, UpdateBookDto book);
        List<GetBookByIdDto> Search(string title, int? categoryId, double? minPrice);
        GetBookByIdDto GetById(int id, bool withCategory = false);
        List<GetAllBooksDto> GetAll(int page, int pageSize);
    }
}
