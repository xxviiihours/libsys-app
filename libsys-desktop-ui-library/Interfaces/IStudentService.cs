using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetAll();
        Task<List<StudentModel>> GetByStudentId(string studentId);
        Task Save(StudentModel studentModel);
        Task Update(int id, StudentModel studentModel);

    }
}
