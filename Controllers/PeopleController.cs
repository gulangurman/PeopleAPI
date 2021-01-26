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

            if (_context.Author.Count() == 0)
            {
                // Add an author
                var author = new Author
                {
                    Name = "H. G. Wells"
                };
                _context.Author.Add(author);
                _context.SaveChanges();
            }

            return _context.Author.ToList();
        }

        [HttpGet("book")]
        public IList<Book> GetBooks()
        {
            if (_context.Book.Count() == 0)
            {
                //add a book
                var book = new Book { Title = "1984", ISBN = "123456787", AuthorId=1 };
                _context.Book.Add(book);
                _context.SaveChanges();
            }

            return _context.Book.ToList();
        }

    }

}