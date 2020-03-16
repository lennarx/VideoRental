using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRental.Context;
using VideoRental.Dtos;
using VideoRental.Models;

namespace VideoRental.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly VideoRentalDbContext _context;

        public CustomersController()
        {
            _context = new VideoRentalDbContext();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var customers = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            if (customers == null)
                return BadRequest("No customers found");

            return Ok(customers);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
                return BadRequest("No customer found for matching criteria");

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult PostMovie([FromBody]CustomerDto customerDto)
        {
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            if (customer.Id == 0)
                return BadRequest("An error occurred while updating the customer");

            customerDto.Id = customer.Id;
            return Ok(customerDto);
        }

        [HttpPut]
        public IHttpActionResult PutMovie([FromBody] CustomerDto customerDto)
        {
            var customerInDb = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == customerDto.Id);

            if (customerInDb == null)
                return BadRequest("Customer not found");

            Mapper.Map(customerDto, customerInDb);

            return Ok("");
        }
    }
}
