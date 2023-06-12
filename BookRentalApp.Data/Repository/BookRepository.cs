using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var b = _context.Books.FirstOrDefault(x => x.Id == id);
            
            _context.Books.Remove(b);

            _context.SaveChanges();
        }

        public Book Update(int id, Book book)
        {
            var b = _context.Books.FirstOrDefault(x => x.Id == id);
            
            b.Title = book.Title;
            b.Author = book.Author;
            b.Publisher = book.Publisher;
            b.ISBN = book.ISBN;
            b.Page = book.Page;
            b.Price = book.Price;
            b.FirstEditionYear = book.FirstEditionYear;
            b.Translator = book.Translator;
            b.Language = book.Language;

            var category = _context.Categories.FirstOrDefault(x => x.Id == book.CategoryId);

            b.CategoryId = book.CategoryId;

            _context.SaveChanges();
            return b;
        }

        public List<Book> GetAll(int page, int pageSize)
        {
            return _context.Books.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Book GetById(int id, bool withCategory = false)
        {
            var query = _context.Books.AsQueryable();

            if (withCategory)
                query = query.Include(x => x.Category);

            var book = query.FirstOrDefault(x => x.Id == id);

            return book;
        }

        public List<Book> Search(string title, string author, string publisher, string ISBN,
            int? categoryId, double? minPrice, string categoryName, bool? isAvailable)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
                query = query.Where(x => x.Title.Contains(title));

            if (!string.IsNullOrWhiteSpace(author))
                query = query.Where(x => x.Author.Contains(author));

            if (!string.IsNullOrWhiteSpace(publisher))
                query = query.Where(x => x.Publisher.Contains(publisher));

            if (!string.IsNullOrWhiteSpace(ISBN))
                query = query.Where(x => x.ISBN == ISBN);

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId);

            if (minPrice.HasValue)
                query = query.Where(x => x.Price > minPrice);

            if (!string.IsNullOrWhiteSpace(categoryName))
                query = query.Where(x => x.Category.Name == categoryName);

            if (isAvailable.HasValue)
                if(isAvailable == true)
                {
                    query = query.Where(x => x.IsAvailable == true);
                }
                else
                {
                    query = query.Where(x => x.IsAvailable == false);
                }
                

            return query.ToList();
        }

        public Book SetAvailability(int id, bool availability)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id); 
            book.IsAvailable = availability;
            return book;
        }

        
    }
}
