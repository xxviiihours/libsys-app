using libsys_api_library.DataAccess;
using libsys_api_library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: api/v2/Books
        [HttpGet]
        [Route("books")]
        public ActionResult GetAll()
        {
            BookData data = new BookData();
            var result = data.GetAllBooks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/v2/Books
        [HttpGet]
        [Route("books/available")]
        public ActionResult GetAllAvailable()
        {
            BookData data = new BookData();
            var result = data.GetAllAvailableBooks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/v2/Books/5
        [HttpGet]
        [Route("books/id/")]
        public ActionResult GetById(int Id)
        {
            BookData data = new BookData();
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
        public ActionResult GetAvailableBooksByTitle(string bookTitle)
        {
            BookData data = new BookData();
            var result = data.GetAvailableBooksByTitle(bookTitle);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/v2/Books
        [Authorize]
        [HttpPost]
        [Route("books/save")]
        public void Post([FromBody] BookModel bookDetails)
        {
            BookData data = new BookData();
            data.SaveBookInfo(bookDetails);
        }

        // PUT: api/v2/Books/5
        [Authorize]
        [HttpPut]
        [Route("books/update/")]
        public void Put(int id, [FromBody] BookModel bookDetails)
        {
            BookData data = new BookData();
            data.UpdateBookInfo(id, bookDetails);
        }

        // DELETE: api/v2/Books/5
        [Authorize]
        [HttpDelete]
        [Route("books/delete/")]
        public void Delete(int id)
        {
            BookData data = new BookData();
            data.DeleteBookInfo(id);
        }
    }
}
