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
    public class BooksController : ApiController
    {
        // GET: api/Books
        public IHttpActionResult Get()
        {
            BookData data = new BookData();
            var result = data.GetAllBooks();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Books/5
        public IHttpActionResult GetById(string Id)
        {
            BookData data = new BookData();
            var result = data.GetBookById(Id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        // POST: api/Books
        public void Post([FromBody]BookDetailModel bookDetails)
        {
            BookData data = new BookData();
            data.SaveBookInfo(bookDetails);
        }

        // PUT: api/Books/5
        [Authorize]
        public void Put(string id, [FromBody]BookDetailModel bookDetails)
        {
            BookData data = new BookData();
            data.UpdateBookInfo(id, bookDetails);
        }

        // DELETE: api/Books/5
        [Authorize]
        public void Delete(string id)
        {
            BookData data = new BookData();
            data.DeleteBookInfo(id);
        }
    }
}
