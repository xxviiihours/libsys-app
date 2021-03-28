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
    [Route("api/v2")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: api/v2/students
        [Authorize]
        [HttpGet]
        [Route("students")]
        public IActionResult Get()
        {
            StudentData data = new StudentData(configuration);
            var result = data.GetAllStudents();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/v2/students/student-id/5
        [HttpGet]
        [Route("students/student-id/")]
        public IActionResult GetByStudentId(string studentId)
        {
            StudentData data = new StudentData(configuration);
            var result = data.GetStudentById(studentId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/v2/students/save
        [Authorize]
        [HttpPost]
        [Route("students/save")]
        public void Post([FromBody] StudentModel studentModel)
        {
            StudentData data = new StudentData(configuration);
            data.SaveStudentInfo(studentModel);
        }

        // PUT: api/v2/students/update/5
        [Authorize]
        [HttpPut]
        [Route("students/update/")]
        public void Put(int id, [FromBody] StudentModel studentModel)
        {
            StudentData data = new StudentData(configuration);
            data.UpdateStudentInfo(id, studentModel);
        }

        // DELETE: api/v2/students/delete/5
        [Authorize]
        [HttpDelete]
        [Route("students/delete/")]
        public void Delete(int id)
        {
            StudentData data = new StudentData(configuration);
            data.DeleteStudentInfo(id);
        }
    }
}
