using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly PeopleContext _context;
        public CustomersController(PeopleContext context)
        {
            _context = context;
        }
        //_context.Database.EnsureDeleted();
        //if (_context.Customer.Count() == 0)
        //{
        //    Customer customer = new Customer { Firstname = "Jack", Lastname = "Sparrow" };
        //    _context.Customer.Add(customer);
        //    Order order = new Order { Customer = customer, Total = 19.99M, Details = "Sale" };
        //    _context.Order.Add(order);
        //    Order order2 = new Order { Customer = customer, Total = 59.99M, Details = "Sale" };
        //    _context.Order.Add(order2);
        //    //_context.SaveChanges();
        //    //var newCustomer =_context.Customer.First();
        //    //Order order = new Order { CustomerId = newCustomer.Id, Total = 19.99M, Details = "Sale" };
        //    //_context.Add(order);
        //    _context.SaveChanges();
        //}   

        [HttpGet]
        public IList<Customer> Get()
        {   
            _context.Database.EnsureCreated();                    
            return _context.Customer
                .Include(c => c.Orders)
                .ToList();
        }

     
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
