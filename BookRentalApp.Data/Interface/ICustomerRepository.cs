using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Data.Interface
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(int id);
        Customer Update(int id, Customer customer);
        List<Customer> GetAll(int page, int pageSize);
        Customer GetById(int id);
    }
}
