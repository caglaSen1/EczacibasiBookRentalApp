using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BookRentalApp.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookRentalAppDbContext _context;

        public BookRepository(BookRentalAppDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Books.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");
            
            _context.Books.Remove(p);

            _context.SaveChanges();
        }

        public Book Update(int id, Book book)
        {
            var p = _context.Books.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");
            
            p.Title = book.Title;
            p.Author = book.Author;
            p.Publisher = book.Publisher;
            p.ISBN = book.ISBN;
            p.Page = book.Page;
            p.Price = book.Price;
            p.IsAvailable = book.IsAvailable;

            var category = _context.Categories.FirstOrDefault(x => x.Id == book.CategoryId) ?? throw new Exception("Category Not Found");
            
            p.CategoryId = book.CategoryId;

            _context.SaveChanges();
            return p;
        }

        public List<Book> GetAll(int page, int pageSize)
        {
            return _context.Books.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Book GetById(int id, bool withCategory = false)
        {
            var query = _context.Books.AsQueryable();

            if (withCategory)
                query.Include(x => x.Category);

            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> Search(string title, int? categoryId, double? minPrice)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
                query.Where(x => x.Title.Contains(title));

            if (categoryId.HasValue)
                query.Where(x => x.CategoryId == categoryId);

            if (minPrice.HasValue)
                query.Where(x => x.Price > minPrice);

            return query.ToList();
        }

    }
}
