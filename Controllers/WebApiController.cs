﻿using System.Linq;
using Dotnet_MVC_Vidly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_MVC_Vidly.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class WebApiController : Controller
    {

        private ApplicationDbContext _context;


        public WebApiController()
        {
            _context = new ApplicationDbContext();
        }

        // GET
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_context.Movies.Include(c => c.Genre).ToList());
        }
    }
}