using BookRentalApp.Data.Entity;
using System.Collections.Generic;

namespace BookRentalApp.Data.Interface
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book Delete(int id);
        Book Update(int id, Book book);
        List<Book> Search(string title, string author, string publisher, string ISBN,
            int? categoryId, double? minPrice, string categoryName, bool? isAvailable);
        Book GetById(int id, bool withCategory = false);
        List<Book> GetAll(int page, int pageSize);

        Book SetAvailability(int id, bool availability);
        Book GetByTitle(string title, bool withCategory = false);
        Book GetByISBN(string ISBN, bool withCategory = false);
    }
}
