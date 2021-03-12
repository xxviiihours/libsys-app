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
    public class TransactionController : ApiController
    {
        // GET: api/Borrow
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Borrow/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Borrow
        [Authorize]
        [HttpPost]
        [Route("api/transaction/borrow/save")]
        public void Post([FromBody] BorrowListModel borrowList)
        {
            TransactionData data = new TransactionData();
            data.SaveBorrowInfo(borrowList);
        }

        // PUT: api/Borrow/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Borrow/5
        public void Delete(int id)
        {
        }
    }
}
