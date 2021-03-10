using libsys_api.Models;
using libsys_api_library.DataAccess;
using libsys_api_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace libsys_api.Controllers
{
    public class BookController : ApiController
    {
        [HttpGet]
        // GET: api/Books
        [Route("api/books")]
        public IHttpActionResult GetAll()
        {
            BookData data = new BookData();
            var result = data.GetAllBooks();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        // GET: api/Books
        [Route("api/books/available")]
        public IHttpActionResult GetAllAvailable()
        {
            BookData data = new BookData();
            var result = data.GetAllAvailableBooks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        // GET: api/Books/5
        [Route("api/books/id/")]
        public IHttpActionResult GetById(int Id)
        {
            BookData data = new BookData();
            var result = data.GetBookById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/books/available/title")]
        public IHttpActionResult GetAvailableBooksByTitle(string bookTitle)
        {
            BookData data = new BookData();
            var result = data.GetAvailableBooksByTitle(bookTitle);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("api/books/save")]
        // POST: api/Books
        public void Post([FromBody]BookModel bookDetails)
        {
            BookData data = new BookData();
            data.SaveBookInfo(bookDetails);
        }

        // PUT: api/Books/5
        [Authorize]
        [HttpPut]
        [Route("api/books/update/")]
        public void Put(int id, [FromBody]BookModel bookDetails)
        {
            BookData data = new BookData();
            data.UpdateBookInfo(id, bookDetails);
        }

        // DELETE: api/Books/5
        [Authorize]
        [HttpDelete]
        [Route("api/books/delete/")]
        public void Delete(int id)
        {
            BookData data = new BookData();
            data.DeleteBookInfo(id);
        }
    }
}
