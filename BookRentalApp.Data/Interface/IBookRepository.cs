using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Data.Interface
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Delete(int id);
        Book Update(int id, Book book);
        List<Book> Search(string title, int? categoryId, double? minPrice);
        Book GetById(int id, bool withCategory = false);
        List<Book> GetAll(int page, int pageSize);
    }
}
