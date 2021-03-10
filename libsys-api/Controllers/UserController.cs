using libsys_api_library.DataAcess;
using libsys_api_library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace libsys_api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        // GET: api/User
        [Route("api/users")]
        public IEnumerable<UserModel> Get()
        {
            return null;
        }

        // GET: api/User/5
        [Route("api/users/id")]
        public UserModel GetById()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            UserData userData = new UserData();
            return userData.GetUserById(id).First();
        }

        // POST api/values
        [Route("api/users/save")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [Route("api/users/update/")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [Route("api/users/delete/")]
        public void Delete(int id)
        {
        }
    }
}
