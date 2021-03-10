using libsys_api_library.DataAccess;
using libsys_api_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace libsys_api.Controllers
{
    public class BookClassificationController : ApiController
    {
        // GET: api/BookClassification
        [Route("api/book-classification")]
        public IHttpActionResult Get()
        {
            BookClassificationData data = new BookClassificationData();
            var result = data.GetAllBookClassification();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/BookClassification/5
        [Route("api/book-classification/id/")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST: api/BookClassification
        [Route("api/book-classification/save")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BookClassification/5
        [Route("api/book-classification/update/")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BookClassification/5
        [Route("api/book-classification/delete/")]
        public void Delete(int id)
        {
        }
    }
}
