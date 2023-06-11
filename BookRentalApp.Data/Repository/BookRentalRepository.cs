using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Data.Repository
{
    public class BookRentalRepository : IBookRentalRepository
    {
        private readonly BookRentalAppDbContext _context;

        public BookRentalRepository(BookRentalAppDbContext context)
        {
            _context = context;
        }

        public void Add(BookRental bookRental)
        {
            _context.BookRentals.Add(bookRental);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.BookRentals.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");

            _context.BookRentals.Remove(p);

            _context.SaveChanges();
        }

        public BookRental Update(int id, BookRental bookRental)
        {
            var p = _context.BookRentals.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");
            
            var customer = _context.Customers.FirstOrDefault(x => x.Id == bookRental.CustomerId) ?? throw new Exception("Customer Not Found");
            
            p.CustomerId = bookRental.CustomerId;

            var book = _context.Books.FirstOrDefault(x => x.Id == bookRental.BookId) ?? throw new Exception("Book Not Found");

            p.BookId = bookRental.BookId;

            p.RentalDate = bookRental.RentalDate;
            p.RentalTerm = bookRental.RentalTerm;
            p.ReturnDate = bookRental.ReturnDate;

            _context.SaveChanges();
            return p;
        }

        public List<BookRental> GetAll(int page, int pageSize)
        {
            return _context.BookRentals.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public BookRental GetById(int id, bool withCustomer = false, bool withBook = false)
        {
            var query = _context.BookRentals.AsQueryable();

            if (withCustomer)
                query.Include(x => x.Customer);
            
            if (withBook)
                query.Include(x => x.Book);

            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<BookRental> GetByCustomerId(int customerId)
        {
            var bookRentals = _context.BookRentals
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Where(x => x.CustomerId == customerId)
                .ToList();

            return bookRentals;
        }

        public List<BookRental> GetByBookId(int bookId)
        {
            var bookRentals = _context.BookRentals
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Where(x => x.BookId == bookId)
                .ToList();

            return bookRentals;
        }

        public List<BookRental> GetOverdueRentals()
        {
            var currentDate = DateTime.Now;

            var overdueRentals = _context.BookRentals
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Where(x => x.ReturnDate == null || x.ReturnDate < currentDate)
                .ToList();

            return overdueRentals;
        }
    }
}
