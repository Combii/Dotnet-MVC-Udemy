using System.Linq;
using Dotnet_MVC_Vidly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_MVC_Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private CustomersList _context;

        public CustomersController()
        {
            _context = new CustomersList();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }
    }
}