using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookRentalApp.Data.Enum;

namespace BookRentalApp.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookRentalAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public BookRepository(BookRentalAppDbContext context, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _context = context;
            _mapper = mapper;   
            _categoryRepository = categoryRepository;
        }

        public Book Add(Book book)
        {   
            _context.Books.Add(book);
            _context.SaveChanges();

            var query = _context.Books.AsQueryable();
            query = query.Include(x => x.Category);

            return query.FirstOrDefault(x => x.Id == book.Id);
        }

        public Book Delete(int id)
        {
            var query = _context.Books.AsQueryable();
            query = query.Include(x => x.Category);

            var book = query.FirstOrDefault(x => x.Id == id);

            _context.Books.Remove(book);
            _context.SaveChanges();
            return book; 
        }

        public Book Update(int id, Book book)
        {
            var updatedBook = _context.Books.FirstOrDefault(x => x.Id == id);
            var tempBook = _mapper.Map<Book>(book);

            if (!string.IsNullOrEmpty(book.Title))
                updatedBook.Title = tempBook.Title;

            if (!string.IsNullOrEmpty(book.Author))
                updatedBook.Author = tempBook.Author;

            if (!string.IsNullOrEmpty(book.Publisher))
                updatedBook.Publisher = tempBook.Publisher;

            if ((book.ISBN) != null)
                updatedBook.ISBN = tempBook.ISBN;
            
            if (!string.IsNullOrEmpty(book.Language))
                updatedBook.Language = tempBook.Language;
         
            if (!string.IsNullOrEmpty(book.Translator))
                updatedBook.Translator = tempBook.Translator;
           
            if ((book.Price) != 0)
                updatedBook.Price = tempBook.Price;
            
            if ((book.Page) != 0)
                updatedBook.Page = tempBook.Page;
           
            if (!string.IsNullOrEmpty(book.FirstEditionYear))
                updatedBook.FirstEditionYear = tempBook.FirstEditionYear;

                        
            if ((book.CategoryId) != 0)
            {
                var category = _categoryRepository.GetById(book.CategoryId);
                if(category != null)
                    updatedBook.CategoryId = tempBook.CategoryId;
            }                            
            _context.SaveChanges();
            return updatedBook;

        }

        public List<Book> GetAll(int page = 0, int pageSize = 5, SortBy sortBy = SortBy.Default)
        {
            var query = _context.Books.AsQueryable();
            query = query.Include(x => x.Category);

            switch (sortBy)
            {
                case SortBy.Alphabetic:
                    query = query.OrderBy(x => x.Title);
                    break;
                case SortBy.Ascending:
                    query = query.OrderBy(x => x.Price);
                    break;
                case SortBy.Descending:
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    break;
            }

            return query.Skip(page * pageSize).Take(pageSize).ToList();
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
            int? categoryId, double? minPrice, string categoryName, bool? isAvailable, SortBy sortBy = SortBy.Default)
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
                query = query.Where(x => x.Price >= minPrice);

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

            switch (sortBy)
            {
                case SortBy.Alphabetic:
                    query = query.OrderBy(x => x.Title);
                    break;
                case SortBy.Ascending:
                    query = query.OrderBy(x => x.Price);
                    break;
                case SortBy.Descending:
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    break;
            }

            return query.ToList();
        }

        public Book SetAvailability(int id, bool availability)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id); 
            book.IsAvailable = availability;
            return book;
        }

        public List<Book> GetByTitle(string title, bool withCategory = false, SortBy sortBy = SortBy.Default)
        {
            var query = _context.Books.AsQueryable();

            if (withCategory)
                query = query.Include(x => x.Category);

            switch (sortBy)
            {
                case SortBy.Alphabetic:
                    query = query.OrderBy(x => x.Title);
                    break;
                case SortBy.Ascending:
                    query = query.OrderBy(x => x.Price);
                    break;
                case SortBy.Descending:
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    break;
            }

            query = query.Where(x => x.Title.ToLower().Equals(title.ToLower()));

            return query.ToList();
        }

        public List<Book> GetByISBN(string ISBN, bool withCategory = false, SortBy sortBy = SortBy.Default)
        {
            var query = _context.Books.AsQueryable();

            if (withCategory)
                query = query.Include(x => x.Category);

            switch (sortBy)
            {
                case SortBy.Alphabetic:
                    query = query.OrderBy(x => x.Title);
                    break;
                case SortBy.Ascending:
                    query = query.OrderBy(x => x.Price);
                    break;
                case SortBy.Descending:
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    break;
            }

            query = query.Where(x => x.ISBN.ToLower().Equals(ISBN.ToLower()));

            return query.ToList();
        }
    }
}
