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
    public class StudentController : ApiController
    {
        [Authorize]
        // GET: api/Student
        public IHttpActionResult Get()
        {
            StudentData data = new StudentData();
            var result = data.GetAllStudents();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Student/5
        public IHttpActionResult GetById(string Id)
        {
            StudentData data = new StudentData();
            var result = data.GetStudentById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        // POST: api/Student
        public void Post([FromBody]StudentModel studentModel)
        {
            StudentData data = new StudentData();
            data.SaveStudentInfo(studentModel);
        }

        [Authorize]
        // PUT: api/Student/5
        public void Put(int id, [FromBody] StudentModel studentModel)
        {
            StudentData data = new StudentData();
            data.UpdateStudentInfo(id, studentModel);
        }

        [Authorize]
        // DELETE: api/Student/5
        public void Delete(int id)
        {
            StudentData data = new StudentData();
            data.DeleteStudentInfo(id);
        }
    }
}
