using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class StudentData
    {
        private readonly IConfiguration configuration;

        public StudentData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<StudentModel> GetAllStudents()
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);

            var output = sql.LoadData<StudentModel, dynamic>("dbo.spGetAllStudentInfo", new { }, "libsys_data");
            return output;
        }

        public void SaveStudentInfo(StudentModel studentModel)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            sql.SaveData("dbo.spInsertStudentInfo", studentModel, "libsys_data");
        }

        public StudentModel GetStudentById(string studentId)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            StudentModel studentModel = new StudentModel();
            var param = new { studentId = studentId };

            var output = sql.LoadData<StudentModel, dynamic>("dbo.spStudentInfoLookup", param, "libsys_data");
            if (output.Count > 0)
            {
                foreach (var item in output)
                {
                    studentModel = item;
                }
                return studentModel;
            }
            return null;
        }

        public void UpdateStudentInfo(int Id, StudentModel studentModel)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            var param = new
            {
                StudentId = studentModel.StudentId,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Gender = studentModel.Gender,
                GradeLevel = studentModel.GradeLevel,
                PhoneNumber = studentModel.PhoneNumber,
                EmailAddress = studentModel.EmailAddress,
                ModifiedBy = studentModel.ModifiedBy,
                LastModified = studentModel.LastModified,

                Id = Id
            };
            sql.UpdateData<StudentModel, dynamic>("dbo.spUpdateStudentInfo", param, "libsys_data");
        }

        public void DeleteStudentInfo(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            var param = new { Id = Id };
            sql.DeleteData("dbo.spDeleteStudentInfo", param, "libsys_data");
        }
    }
}
