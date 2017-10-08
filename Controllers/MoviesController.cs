using System;
using System.Collections.Generic;
using System.Linq;
using Dotnet_MVC_Vidly.Models;
using Dotnet_MVC_Vidly.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
             return _context.Movies.Include(c => c.Genre).ToList();
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
        
        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            
            var newGenre = _context.Genres.Single(c => c.Id == movie.Genre.Id);

            
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.Genre = newGenre;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberOfStock = movie.NumberOfStock;
                movieInDb.Genre = newGenre;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            
            return View("MovieForm", viewModel);
        }
    }
}