using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Models
{
    public class BorrowListModel
    {

        public List<BorrowModel> BorrowedBookDetails { get; set; } = new List<BorrowModel>();
    }
}
