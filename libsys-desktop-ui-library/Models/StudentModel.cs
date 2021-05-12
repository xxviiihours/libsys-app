using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Models
{
    public class StudentModel
    {
         public int Id { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string GradeLevel { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int BorrowLimit { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;

    }
}
