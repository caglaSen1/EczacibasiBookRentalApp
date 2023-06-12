using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookRentalApp.Data.Repository
{
    public class RentedBookRepository : IRentedBookRepository
    {
        private readonly BookRentalAppDbContext _context;

        public RentedBookRepository(BookRentalAppDbContext context)
        {
            _context = context;
        }

        public void Add(RentedBook rentedBook)
        {
            _context.RentedBooks.Add(rentedBook);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var b = _context.RentedBooks.FirstOrDefault(x => x.Id == id);

            _context.RentedBooks.Remove(b);

            _context.SaveChanges();
        }

        public RentedBook Update(int id, RentedBook rentedBook)
        {
            var b = _context.RentedBooks.FirstOrDefault(x => x.Id == id);

            var customer = _context.Customers.FirstOrDefault(x => x.Id == rentedBook.CustomerId);

            b.CustomerId = rentedBook.CustomerId;

            var book = _context.Books.FirstOrDefault(x => x.Id == rentedBook.BookId);

            b.BookId = rentedBook.BookId;

            b.RentalDate = rentedBook.RentalDate;
            b.HowManyDaysToRent = rentedBook.HowManyDaysToRent;
            b.MustReturnDate = rentedBook.MustReturnDate;

            _context.SaveChanges();
            return b;
        }

        public List<RentedBook> GetAll(int page, int pageSize)
        {
            return _context.RentedBooks.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public RentedBook GetById(int id, bool withCustomer = false, bool withBook = false)
        {
            var query = _context.RentedBooks.AsQueryable();

            if (withBook)
                query = query.Include(x => x.Book);

            if (withCustomer)
                query = query.Include(x => x.Customer);

            var rentedBook = query.FirstOrDefault(x => x.Id == id);

            return rentedBook;
        }

        public RentedBook GetByBookId(int id)
        {
            var query = _context.RentedBooks.AsQueryable();
            var rentedBook = query.FirstOrDefault(x => x.BookId == id);

            return rentedBook;
        }

        public RentedBook GetByCustomerId(int id)
        {
            var query = _context.RentedBooks.AsQueryable();
            var rentedBook = query.FirstOrDefault(x => x.CustomerId == id);

            return rentedBook;
        }

       
        public List<RentedBook> GetPreviousRentals()
        {
            var currentDate = DateTime.Now;

            var overdueRentals = _context.RentedBooks
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Where(x => x.MustReturnDate <= currentDate)
                .ToList();

            return overdueRentals;
        }

        public List<RentedBook> GetCurrentRentals()
        {
            var currentDate = DateTime.Now;

            var currentRentals = _context.RentedBooks
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Where(x => x.MustReturnDate > currentDate)
                .ToList();

            return currentRentals;
        }

        public List<RentedBook> Search(int? customerId, int? bookId, DateTime? rentalDate, byte? howManyDaysToRent, DateTime? returnDate)
        {
            var query = _context.RentedBooks.AsQueryable();


            if(customerId.HasValue)
                query = query.Where(x => x.CustomerId == customerId);

            if (bookId.HasValue)
                query = query.Where(x => x.BookId == bookId);

            if (rentalDate.HasValue)
                query = query.Where(x => x.MustReturnDate.Equals(rentalDate.Value));

            if (howManyDaysToRent.HasValue)
                query = query.Where(x => x.HowManyDaysToRent == howManyDaysToRent);

            if (returnDate.HasValue)
                query = query.Where(x => x.MustReturnDate.Equals(returnDate.Value));

            
                    
            return query.ToList();
        }

        public RentedBook DeliverBook(int id)
        {
            var rentedBook = _context.RentedBooks.FirstOrDefault(x => x.Id == id);
            rentedBook.ReturnDate = DateTime.Now;
            _context.SaveChanges();
            return rentedBook;


        }
    }
}
