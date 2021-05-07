using libsys_api_library.DataAccess;
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
    public class ReportController : ControllerBase
    {

        private readonly IConfiguration configuration;

        public ReportController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: api/v2/reports/borrowed-books/
        [HttpGet]
        [Route("reports/borrowed-books/")]
        public IActionResult GetAllBorrowedBooks()
        {
            Console.WriteLine();
            ReportData data = new ReportData(configuration);
            var result = data.GetAllBorrowedBooks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/v2/reports/overdue/
        [HttpGet]
        [Route("reports/overdue/")]
        public IActionResult GetAllOverduedBooks()
        {
            ReportData data = new ReportData(configuration);
            var result = data.GetAllOverDuedBooks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
