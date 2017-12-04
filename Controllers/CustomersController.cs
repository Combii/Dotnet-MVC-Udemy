using System.Linq;
using Dotnet_MVC_David.Data.Repositories;
using Dotnet_MVC_Vidly.Models;
using Dotnet_MVC_Vidly.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_MVC_Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private readonly CustomerRepository customerRepository;

        public CustomersController()
        {
             customerRepository = new CustomerRepository(new ApplicationDbContext());
        }
        

        public ViewResult Index()
        {
            return View(customerRepository.GetCustomers());
        }
        
        public IActionResult New()
        {
            var membershipTypes = customerRepository.GetMembershipTypes();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            
            return View("CustomerForm", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = customerRepository.GetMembershipTypes();
                };

                return View("CustomerForm", viewModel);
            }

                       
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            
            return View("CustomerForm", viewModel);
        }*/
    }
}