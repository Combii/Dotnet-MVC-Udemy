using System.ComponentModel.DataAnnotations;

namespace Dotnet_MVC_Vidly.Models
{
    public class Genre
    {
        [Display (Name = "Genre")]
        public int Id { get; set; }
        public string GenreName { get; set; }
    }
}