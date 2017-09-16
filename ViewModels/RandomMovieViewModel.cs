using System.Collections.Generic;
using Dotnet_MVC_Vidly.Models;

namespace Dotnet_MVC_Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}