using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using VideoRental.Context;
using VideoRental.Models;
using VideoRental.ViewModels;

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
            var movies = _context.Movies.Include(x => x.Genre)
                .AsNoTracking().OrderBy(x => x.MovieId).Take(10).ToList();

            if (movies == null || movies.Count == 0)
                return HttpNotFound();

            return View(movies);
        }

        public ActionResult New()
        {
            var viewModel = new MovieViewModel
            {
                PageTitle = "New Movie",
                Genres = _context.Genres.AsNoTracking().ToList()
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MovieViewModel
            {
                PageTitle = "Edit Movie",
                Movie = _context.Movies.AsNoTracking().FirstOrDefault(x => x.MovieId == id),
                Genres = _context.Genres.AsNoTracking().ToList()
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.MovieId == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieToInsert = _context.Movies.AsNoTracking().FirstOrDefault(x => x.MovieId == movie.MovieId);

                movieToInsert.Name = movie.Name;
                movieToInsert.GenreId = movie.GenreId;
                movieToInsert.DateAdded = movie.DateAdded;
                movieToInsert.ReleaseDate = movie.ReleaseDate;
                movieToInsert.NumberInStock = movie.NumberInStock;
                movieToInsert.MoviesAvailables = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
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