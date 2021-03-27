using libsys_api_library.DataAccess;
using libsys_api_library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        // GET: api/v2/Students
        [Route("students")]
        public ActionResult Get()
        {
            StudentData data = new StudentData();
            var result = data.GetAllStudents();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/v2/Students/5
        [Route("students/student-id/")]
        public ActionResult GetByStudentId(string studentId)
        {
            StudentData data = new StudentData();
            var result = data.GetStudentById(studentId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        // POST: api/v2/Students
        [Route("students/save")]
        public void Post([FromBody] StudentModel studentModel)
        {
            StudentData data = new StudentData();
            data.SaveStudentInfo(studentModel);
        }

        [Authorize]
        // PUT: api/v2/Students/5
        [Route("students/update/")]
        public void Put(int id, [FromBody] StudentModel studentModel)
        {
            StudentData data = new StudentData();
            data.UpdateStudentInfo(id, studentModel);
        }

        [Authorize]
        // DELETE: api/v2/Students/5
        [Route("students/delete/")]
        public void Delete(int id)
        {
            StudentData data = new StudentData();
            data.DeleteStudentInfo(id);
        }
    }
}
