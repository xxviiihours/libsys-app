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
    [Authorize]
    public class ViolationController : ApiController
    {
        // GET: api/Violation
        [HttpGet]
        [Route("api/violation")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Violation/5
        [HttpGet]
        [Route("api/violation/id/")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Violation
        [HttpPost]
        [Route("api/violation/save")]
        public void Post([FromBody]ViolationModel violationModel)
        {
            ViolationData violationData = new ViolationData();
            violationData.SaveViolation(violationModel);
        }

        // PUT: api/Violation/5
        [HttpPut]
        [Route("api/violation/update/")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Violation/5
        [HttpDelete]
        [Route("api/violation/delete/")]
        public void Delete(int id)
        {
        }
    }
}
