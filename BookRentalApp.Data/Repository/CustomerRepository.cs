using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookRentalApp.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookRentalAppDbContext _context;

        public CustomerRepository(BookRentalAppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Customers.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");
            
            _context.Customers.Remove(p);

            _context.SaveChanges();
        }

        public Customer Update(int id, Customer customer)
        {
            var p = _context.Customers.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Not Found");

            p.FirstName = customer.FirstName;
            p.LastName = customer.LastName;
            p.Address = customer.Address;   
            p.Phone =  customer.Phone;
            p.Email = customer.Email;

            return p;
        }

        public List<Customer> GetAll(int page, int pageSize)
        {
            return _context.Customers.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
