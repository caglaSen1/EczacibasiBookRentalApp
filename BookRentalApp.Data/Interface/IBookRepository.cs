using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Enum;
using System.Collections.Generic;

namespace BookRentalApp.Data.Interface
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book Delete(int id);
        Book Update(int id, Book book);
        List<Book> Search(string title, string author, string publisher, string ISBN,
            int? categoryId, double? minPrice, string categoryName, bool? isAvailable, SortBy sortBy = SortBy.Default);
        Book GetById(int id, bool withCategory = false);
        List<Book> GetAll(int page, int pageSize, SortBy sortBy = SortBy.Default);
        Book SetAvailability(int id, bool availability);
        Book GetByTitle(string title, bool withCategory = false, SortBy sortBy = SortBy.Default);
        Book GetByISBN(string ISBN, bool withCategory = false, SortBy sortBy = SortBy.Default);
    }
}
