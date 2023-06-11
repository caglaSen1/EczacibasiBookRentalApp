using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Data.Interface
{
    public interface IBookRentalRepository
    {
        void Add(BookRental bookRental);
        void Delete(int id);
        BookRental Update(int id, BookRental bookRental);
        BookRental GetById(int id, bool withCustomer = false, bool withBook = false);
        List<BookRental> GetAll(int page, int pageSize);
        List<BookRental> GetByCustomerId(int customerId);
        List<BookRental> GetByBookId(int bookId);
        List<BookRental> GetOverdueRentals();
    }
}
