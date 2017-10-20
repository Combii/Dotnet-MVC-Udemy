using System.ComponentModel.DataAnnotations;

namespace Dotnet_MVC_Vidly.Models
{
    public class Genre
    {
        [Display(Name = "Genre")]
        [Required]
        public int? Id { get; set; }
        public string GenreName { get; set; }
    }
}