using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRental.Context;
using VideoRental.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly VideoRentalDbContext _context;

        public CustomersController()
        {
            _context = new VideoRentalDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {            
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}