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
    [Authorize]
    [Route("api/v2")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ViolationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: api/v2/violation
        [HttpGet]
        [Route("violations")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/v2/violation/5
        [HttpGet]
        [Route("violations/id/")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/v2/violation/save
        [HttpPost]
        [Route("violations/save")]
        public void Post([FromBody] ViolationModel violationModel)
        {
            ViolationData violationData = new ViolationData(configuration);
            violationData.SaveViolation(violationModel);
        }

        // PUT: api/v2/violation/update/5
        [HttpPut]
        [Route("violations/update/")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/v2/violation/delete/5
        [HttpDelete]
        [Route("violations/delete/")]
        public void Delete(int id)
        {
        }
    }
}
