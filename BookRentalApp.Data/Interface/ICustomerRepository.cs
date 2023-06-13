using BookRentalApp.Data.Entity;
using System.Collections.Generic;

namespace BookRentalApp.Data.Interface
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        Customer Delete(int id);
        Customer Update(int id, Customer customer);
        List<Customer> GetAll(int page, int pageSize);
        Customer GetById(int id);
    }
}
