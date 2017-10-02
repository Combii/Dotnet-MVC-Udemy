using System.Collections.Generic;
using Dotnet_MVC_Vidly.Models;

namespace Dotnet_MVC_Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}