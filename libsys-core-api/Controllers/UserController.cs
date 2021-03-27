using libsys_api_library.DataAcess;
using libsys_api_library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace libsys_core_api.Controllers
{
    [Route("api/v2")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/v2/Users
        [HttpGet]
        [Route("users")]
        public IEnumerable<UserModel> Get()
        {
            return null;
        }

        // GET: api/v2/Users/5
        [HttpGet]
        [Route("users/id")]
        public UserModel GetById()
        {
            //string id = RequestContext.Principal.Identity.GetUserId();
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserData userData = new UserData();
            return userData.GetUserById(id).First();
        }

        // POST api/v2/Users/save
        [HttpPost]
        [Route("users/save")]
        public void Post([FromBody] string value)
        {
        }

        // PUT  api/v2/Users/update/5
        [HttpPut]
        [Route("users/update/")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE  api/v2/Users/delete/
        [HttpDelete]
        [Route("users/delete/")]
        public void Delete(int id)
        {
        }
    }
}
