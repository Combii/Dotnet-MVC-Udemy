using System.Collections.Generic;
using Dotnet_MVC_Vidly.Models;

namespace Dotnet_MVC_Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
    
}