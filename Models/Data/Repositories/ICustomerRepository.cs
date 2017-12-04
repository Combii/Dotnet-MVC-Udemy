using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_MVC_Vidly.Models;

namespace Dotnet_MVC_David.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        void InsertCustomer(Customer customer);
        Customer DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
       
    }
}
