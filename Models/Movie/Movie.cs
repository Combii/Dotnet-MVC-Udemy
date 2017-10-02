using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet_MVC_Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        public Genre Genre{ get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberOfStock { get; set; }
    }
}