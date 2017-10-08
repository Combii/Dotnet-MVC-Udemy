﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet_MVC_Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public Genre Genre{ get; set; }
        
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        [Display (Name = "Number in Stock")]
        public int NumberOfStock { get; set; }
    }
}