using libsys_api_library.DataAccess;
using libsys_api_library.Models;
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
    public class TransactionController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public TransactionController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: api/v2/transactions
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/v2/transactions/5
        [HttpGet]
        [Route("transactions/classification-id")]
        public ActionResult GetAllBorrowedBooksByClassificationId(string classificationId)
        {
            Console.WriteLine();
            TransactionData data = new TransactionData(configuration);
            var result = data.GetBorrowedBooksByClassificationId(classificationId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/v2/transactions/save
        [HttpPost]
        [Route("transactions/borrow/save")]
        public void Post([FromBody] BorrowListModel borrowList)
        {
            TransactionData data = new TransactionData(configuration);
            data.SaveBorrowInfo(borrowList);
        }

        // PUT: api/v2/transactions/update
        [HttpPut]
        [Route("transactions/return/update")]
        public void Put(int id, [FromBody] TransactionModel borrowedBook)
        {
            TransactionData data = new TransactionData(configuration);
            data.Return(id, borrowedBook);
        }

        // DELETE: api/v2/transactions/delete
        public void Delete(int id)
        {
        }
    }
}
