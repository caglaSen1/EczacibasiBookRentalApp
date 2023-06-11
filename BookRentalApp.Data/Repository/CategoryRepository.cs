using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookRentalApp.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookRentalAppDbContext _context;

        public CategoryRepository(BookRentalAppDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {

            _context.Categories.Add(category);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Categories.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");
            
            _context.Categories.Remove(p);

            _context.SaveChanges();
        }

        public Category Update(int id, Category category)
        {
            var p = _context.Categories.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");

            p.Name = category.Name;
            p.Description = category.Description;

            _context.SaveChanges();
            return p;
        }

        public List<Category> GetAll(int page, int pageSize)
        {
            return _context.Categories.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Category GetById(int id)
        {
            var p = _context.Categories.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");
            return p;
        }

    }
}
