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
        public IEnumerable<BookDetailModel> Get()
        {
            return null;
        }

        // GET: api/Books/5
        public BookDetailModel GetById(string Id)
        {
            BookData data = new BookData();
            return data.GetBookById(Id).First();
        }

        [Authorize]
        // POST: api/Books
        public void Post([FromBody]BookDetailModel bookDetails)
        {
            BookData data = new BookData();
            data.SaveBookInfo(bookDetails);
            Ok();
        }

        // PUT: api/Books/5
        [Authorize]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
