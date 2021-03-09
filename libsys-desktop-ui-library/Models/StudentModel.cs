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
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int BorrowLimit { get; set; }

    }
}
