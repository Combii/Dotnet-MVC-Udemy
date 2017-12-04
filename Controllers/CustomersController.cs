using Dotnet_MVC_David.Data.Repositories;
using Dotnet_MVC_Vidly.Models;
using Dotnet_MVC_Vidly.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_MVC_Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private readonly CustomerRepository _customerRepository;

        public CustomersController()
        {
             _customerRepository = new CustomerRepository(new ApplicationDbContext());
        }
        

        public ViewResult Index()
        {
            return View(_customerRepository.GetCustomers());
        }
        
        public IActionResult New()
        {
            var membershipTypes = _customerRepository.GetMembershipTypes();

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
                    MembershipTypes = _customerRepository.GetMembershipTypes()
                };

                return View("CustomerForm", viewModel);
            }
            
            _customerRepository.SaveCustomer(customer);
 
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
                return NotFound();
            

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _customerRepository.GetMembershipTypes()
            };
            
            return View("CustomerForm", viewModel);
        }
    }
}