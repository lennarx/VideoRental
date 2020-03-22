using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using VideoRental.Context;
using VideoRental.ViewModels;

namespace VideoRental.Controllers
{
    public class RentalsController : Controller
    {
        private readonly VideoRentalDbContext _context;

        public RentalsController()
        {
            _context = new VideoRentalDbContext();
        }

        // GET: Rentals
        public ActionResult NewRental(int? customerId = null)
        {
            return View();
        }

        
        public ActionResult AddRents(NewRentViewModel newRental)
        {
            var rentals = new List<VideoRental.Models.Rental>();
            var customer = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(x => newRental.MoviesId.Contains(x.MovieId)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return View("ErrorView", movie);

                rentals.Add(new Models.Rental
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    Movie = movie,
                    DateRented = DateTime.UtcNow
                });
                movie.MoviesAvailables -- ;                
            }

            _context.Rentals.AddRange(rentals);
            _context.SaveChanges();
            
            return RedirectToAction("Customers");
        }

        
    }
}