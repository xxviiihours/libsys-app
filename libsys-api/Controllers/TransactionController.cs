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
    public class TransactionController : ApiController
    {
        // GET: api/Borrow
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Borrow/5
        [HttpGet]
        [Route("api/transaction/classification-id")]
        public IHttpActionResult GetAllBorrowedBooksByClassificationId(string classificationId)
        {
            Console.WriteLine();
            TransactionData data = new TransactionData();
            var result = data.GetBorrowedBooksByClassificationId(classificationId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/Borrow
        [HttpPost]
        [Route("api/transaction/borrow/save")]
        public void Post([FromBody] BorrowListModel borrowList)
        {
            TransactionData data = new TransactionData();
            data.SaveBorrowInfo(borrowList);
        }

        // PUT: api/Borrow/5
        [HttpPut]
        [Route("api/transaction/return/update")]
        public void Put(int id, [FromBody]TransactionModel borrowedBook)
        {
            TransactionData data = new TransactionData();
            data.Return(id, borrowedBook);
        }

        // DELETE: api/Borrow/5
        public void Delete(int id)
        {
        }
    }
}
