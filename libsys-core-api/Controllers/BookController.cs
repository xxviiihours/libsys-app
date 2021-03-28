using libsys_api_library.DataAccess;
using libsys_api_library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libsys_core_api.Controllers
{
    [Route("api/v2")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: api/v2/books
        [HttpGet]
        [Route("books")]
        public IActionResult GetAll()
        {
            BookData data = new BookData(configuration);
            var result = data.GetAllBooks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/v2/books
        [HttpGet]
        [Route("books/available")]
        public IActionResult GetAllAvailable()
        {
            BookData data = new BookData(configuration);
            var result = data.GetAllAvailableBooks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/v2/books/5
        [HttpGet]
        [Route("books/id/")]
        public IActionResult GetById(int Id)
        {
            BookData data = new BookData(configuration);
            var result = data.GetBookById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/v2/books/available/title
        [HttpGet]
        [Route("books/available/title")]
        public IActionResult GetAvailableBooksByTitle(string bookTitle)
        {
            BookData data = new BookData(configuration);
            var result = data.GetAvailableBooksByTitle(bookTitle);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/v2/books/save
        [Authorize]
        [HttpPost]
        [Route("books/save")]
        public void Post([FromBody] BookModel bookDetails)
        {
            BookData data = new BookData(configuration);
            data.SaveBookInfo(bookDetails);
        }

        // PUT: api/v2/books/update/5
        [Authorize]
        [HttpPut]
        [Route("books/update/")]
        public void Put(int id, [FromBody] BookModel bookDetails)
        {
            BookData data = new BookData(configuration);
            data.UpdateBookInfo(id, bookDetails);
        }

        // DELETE: api/v2/books/delete/5
        [Authorize]
        [HttpDelete]
        [Route("books/delete/")]
        public void Delete(int id)
        {
            BookData data = new BookData(configuration);
            data.DeleteBookInfo(id);
        }
    }
}
