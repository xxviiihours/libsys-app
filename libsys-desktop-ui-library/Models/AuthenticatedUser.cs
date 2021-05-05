using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Models
{
    public class AuthenticatedUser
    {

        public string Access_Token { get; set; }

        public string UserName { get; set; }

        public string Id { get; set; }
    }
}
