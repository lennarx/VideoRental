using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using VideoRental.Context;
using VideoRental.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly VideoRentalDbContext _context;

        public MoviesController()
        {
            _context = new VideoRentalDbContext();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();

            return View(movies);
        }   
        
        public ActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.MovieId == id);

            return View(movie);
        }
        
    }
}