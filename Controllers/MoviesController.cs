using System.Collections.Generic;
using System.Linq;
using System.Net;
using Dotnet_MVC_Vidly.Models;
using Dotnet_MVC_Vidly.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
             return _context.Movies.ToList();
        }
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public IActionResult Save()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult New()
        {
            throw new System.NotImplementedException();
        }
    }
}