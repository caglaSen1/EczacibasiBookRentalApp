using AutoMapper;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookRentalApp.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookRentalAppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(BookRentalAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category ;
        }

        public Category Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category ;
        }

        public Category Update(int id, Category category)
        {
            var updatedCategory = _context.Categories.FirstOrDefault(x => x.Id == id);            
            var tempCategory = _mapper.Map<Category>(category);

            if (!string.IsNullOrEmpty(category.Name))
                updatedCategory.Name = tempCategory.Name;
            if (!string.IsNullOrEmpty(category.Description))
                updatedCategory.Description = tempCategory.Description;
                        
            _context.SaveChanges();
            return updatedCategory;  
        }

        public List<Category> GetAll(int page = 0, int pageSize = 5)
        {
            return _context.Categories.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Category GetById(int id, bool withBooks = false)
        {            
            var query = _context.Categories.AsQueryable();

            if (withBooks)
                query = query.Include(x => x.BookList);
            

            var category = query.FirstOrDefault(x => x.Id == id);

            return category;

        }

       /* public List<Book> GetBooksOfCategory(int id)  //booklar categorinin booklist ekleniyo mu bak
        {
            var query = _context.Categories.AsQueryable();
            query = query.Include(x => x.BookList);

            var category = query.FirstOrDefault(x => x.Id == id);

            return category.BookList;
        }*/
    }
}
