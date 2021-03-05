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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookClassification
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BookClassification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BookClassification/5
        public void Delete(int id)
        {
        }
    }
}
