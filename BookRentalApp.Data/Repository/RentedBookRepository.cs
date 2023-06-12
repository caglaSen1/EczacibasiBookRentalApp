using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BookRentalApp.Data.Repository
{
    public class RentedBookRepository : IRentedBookRepository
    {
        private readonly BookRentalAppDbContext _context;

        public RentedBookRepository(BookRentalAppDbContext context)
        {
            _context = context;
        }

        public void Add(RentedBook bookRental)
        {
            _context.BookRentals.Add(bookRental);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var b = _context.BookRentals.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");

            _context.BookRentals.Remove(b);

            _context.SaveChanges();
        }

        public RentedBook Update(int id, RentedBook bookRental)
        {
            var b = _context.BookRentals.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");

            var customer = _context.Customers.FirstOrDefault(x => x.Id == bookRental.CustomerId) ?? throw new Exception("Customer Not Found");

            b.CustomerId = bookRental.CustomerId;

            var book = _context.Books.FirstOrDefault(x => x.Id == bookRental.BookId) ?? throw new Exception("Book Not Found");

            b.BookId = bookRental.BookId;

            b.RentalDate = bookRental.RentalDate;
            b.HowManyDaysToRent = bookRental.HowManyDaysToRent;
            b.ReturnDate = bookRental.ReturnDate;

            _context.SaveChanges();
            return b;
        }

        public List<RentedBook> GetAll(int page, int pageSize)
        {
            return _context.BookRentals.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public RentedBook GetById(int id, bool withCustomer = false, bool withBook = false)
        {
            var query = _context.BookRentals.AsQueryable();

            if (withBook)
                query = query.Include(x => x.Book);

            if (withCustomer)
                query = query.Include(x => x.Customer);

            var bookRental = query.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Book rental Not Found");

            return bookRental;
        }

        public RentedBook GetByBookId(int bookId)
        {
            var query = _context.BookRentals.AsQueryable();
            var bookRental = query.FirstOrDefault(x => x.BookId == bookId) ?? throw new Exception("Book rental Not Found");

            return bookRental;
        }

        public RentedBook GetByCustomerId(int customerId)
        {
            var query = _context.BookRentals.AsQueryable();
            var bookRental = query.FirstOrDefault(x => x.CustomerId == customerId) ?? throw new Exception("Book rental Not Found");

            return bookRental;
        }

       
        public List<RentedBook> GetPreviousRentals()
        {
            var currentDate = DateTime.Now;

            var overdueRentals = _context.BookRentals
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Where(x => x.ReturnDate <= currentDate)
                .ToList();

            return overdueRentals;
        }

        public List<RentedBook> GetCurrentRentals()
        {
            var currentDate = DateTime.Now;

            var currentRentals = _context.BookRentals
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Where(x => x.ReturnDate > currentDate)
                .ToList();

            return currentRentals;
        }

    }
}
