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
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();

            if (movies == null || movies.Count == 0)
                return HttpNotFound();

            return View(movies);
        }   
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.MovieId == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        
    }
}