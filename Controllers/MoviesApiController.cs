using System;
using System.Linq;
using Dotnet_MVC_Vidly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_MVC_Vidly.Controllers
{
    //[Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesApiController : Controller
    {

        private ApplicationDbContext _context;


        public MoviesApiController()
        {
            _context = new ApplicationDbContext();
        }

        // GET
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_context.Movies.Include(c => c.Genre).ToList());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            
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
                //For return statement
                movie.Genre = newGenre;
            }

            _context.SaveChanges();
            
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
            //return StatusCode(200);
        }
        
        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null) return StatusCode(400);
            
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Json(new
            {
                Status="Deleted successfully", 
                movie
            });

        }
        
    }
}