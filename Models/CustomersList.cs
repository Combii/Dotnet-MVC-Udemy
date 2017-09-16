using Microsoft.EntityFrameworkCore;

namespace Dotnet_MVC_Vidly.Models
{
    public class CustomersList : DbContext
    {
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./CustomersDb.db");
        }
    }
}