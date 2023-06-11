using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Data.Interface
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Delete(int id);
        Category Update(int id, Category category);
        List<Category> GetAll(int page, int pageSize);
        Category GetById(int id);
    }
}
