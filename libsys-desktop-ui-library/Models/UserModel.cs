using System;
using System.Collections.Generic;
using System.Text;

namespace libsys_desktop_ui_library.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
