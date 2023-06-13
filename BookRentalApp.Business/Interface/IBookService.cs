using BookRentalApp.Business.Dto.Book;
using System.Collections.Generic;


namespace BookRentalApp.Business.Interface
{
    public interface IBookService
    {
        ServiceResult<GetBookByIdDto> Add(CreateBookDto bookDto);
        ServiceResult<GetBookByIdDto> Delete(int id);
        ServiceResult<GetBookByIdDto> Update(int id, UpdateBookDto bookDto);
        ServiceResult<List<GetAllBooksDto>> GetAll(int page, int pageSize);
        ServiceResult<GetBookByIdDto> GetById(int id, bool withCategory = false);
        ServiceResult<List<GetBookByIdDto>> Search(string title, string author, string publisher, string ISBN,
            int? categoryId, double? minPrice, string categoryName, bool? isAvailable);
        ServiceResult<GetBookByIdDto> SetAvailability(int id, bool availability);
        ServiceResult<GetBookByIdDto> GetByTitle(string title, bool withCategory = false);
        ServiceResult<GetBookByIdDto> GetByISBN(string ISBN, bool withCategory = false);
    }
}
