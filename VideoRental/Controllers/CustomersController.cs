using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRental.Context;
using VideoRental.Models;
using VideoRental.ViewModels;

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
            var customers = _context.Customers.Include(c => c.MembershipType).OrderBy(x => x.Id).Take(10).ToList();

            return View(customers);
        }
        
        public ActionResult New()
        {
            var viewModel = new CustomerViewModel
            {
                PageTitle = "New Customer",
                MembershipTypes = _context.MembershipTypes.AsNoTracking().ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
            {
                var customerToCreate = customer;
                _context.Customers.Add(customerToCreate);                
            }
            else
            {
                var customerToEdit = _context.Customers.FirstOrDefault(x => x.Id == customer.Id);

                if (customerToEdit == null)
                {
                    return HttpNotFound();
                }

                customerToEdit.Name = customer.Name;
                customerToEdit.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
                customerToEdit.BirthDate = customer.BirthDate;
                customerToEdit.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customerViewModel = new CustomerViewModel
            {
                PageTitle = "Edit Customer",
                Customer = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id),
                MembershipTypes = _context.MembershipTypes.AsNoTracking().ToList()
            };

            return View("CustomerForm", customerViewModel);
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