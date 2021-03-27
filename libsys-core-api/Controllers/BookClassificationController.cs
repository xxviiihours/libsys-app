using libsys_api_library.DataAccess;
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
    public class BookClassificationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public BookClassificationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: api/v2/BookClassifications
        [Route("book-classifications")]
        public ActionResult Get()
        {
            BookClassificationData data = new BookClassificationData(configuration);
            var result = data.GetAllBookClassification();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/v2/BookClassifications/5
        [Route("book-classifications/id/")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST: api/v2/BookClassifications
        [Route("book-classifications/save")]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/v2/BookClassifications/5
        [Route("book-classifications/update/")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/v2/BookClassifications/5
        [Route("book-classifications/delete/")]
        public void Delete(int id)
        {
        }
    }
}
