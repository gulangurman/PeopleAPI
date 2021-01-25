using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleAPI.Models;

namespace PeopleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleContext _context;
        public PeopleController(PeopleContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IList<Author> GetAuthors()
        {
            // Creates the database if not exists
            _context.Database.EnsureCreated();

            // Adds a publisher
            var author = new Author
            {
                Name = "H. G. Wells"
            };
            _context.Author.Add(author);
            _context.SaveChanges();
            return _context.Author.ToList();
        }

    }

}