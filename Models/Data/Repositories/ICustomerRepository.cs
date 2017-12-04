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
        IEnumerable<MembershipType> GetMembershipTypes();
        void SaveCustomer(Customer customer);
        Customer DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
       
    }
}
