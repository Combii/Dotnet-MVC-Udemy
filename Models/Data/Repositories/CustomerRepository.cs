using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_MVC_Vidly.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_MVC_David.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {

        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == customerId);
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
        }

        public Customer DeleteCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            InsertCustomer(customer);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
