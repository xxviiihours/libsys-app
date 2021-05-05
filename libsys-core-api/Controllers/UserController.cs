using libsys_api_library.DataAcess;
using libsys_api_library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: api/v2/users
        [HttpGet]
        [Route("users")]
        public IEnumerable<UserModel> Get()
        {
            return null;
        }

        // GET: api/v2/users/id/5
        [HttpGet]
        [Route("users/id")]
        public UserModel GetById()
        {
            //string id = RequestContext.Principal.Identity.GetUserId();
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserData userData = new UserData(configuration);
            return userData.GetUserById(id).First();
        }

        // POST api/v2/users/save
        [HttpPost]
        [Route("users/save")]
        public void Post([FromBody] UserModel userModel)
        {
            UserData userData = new UserData(configuration);
            userData.SaveUserInfo(userModel);
        }

        // PUT  api/v2/users/update/5
        [HttpPut]
        [Route("users/update/")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE  api/v2/users/delete/
        [HttpDelete]
        [Route("users/delete/")]
        public void Delete(int id)
        {
        }
    }
}
