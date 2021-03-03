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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        // GET: api/User
        //public IEnumerable<UserModel> Get()
        //{
        //    return null;
        //}

        // GET: api/User/5
        public UserModel GetById()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            UserData userData = new UserData();
            return userData.GetUserById(id).First();
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
