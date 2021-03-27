using libsys_api_library.DataAccess;
using libsys_api_library.Models;
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
    public class ViolationController : ControllerBase
    {
        // GET: api/Violation
        [HttpGet]
        [Route("violations")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Violation/5
        [HttpGet]
        [Route("violations/id/")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Violation
        [HttpPost]
        [Route("violations/save")]
        public void Post([FromBody] ViolationModel violationModel)
        {
            ViolationData violationData = new ViolationData();
            violationData.SaveViolation(violationModel);
        }

        // PUT: api/Violation/5
        [HttpPut]
        [Route("violations/update/")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Violation/5
        [HttpDelete]
        [Route("violations/delete/")]
        public void Delete(int id)
        {
        }
    }
}
