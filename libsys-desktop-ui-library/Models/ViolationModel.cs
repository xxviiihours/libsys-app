using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Models
{
    public class ViolationModel
    {
        public int Id { get; set; }
        public string ClassificationId { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string OrNumber { get; set; }
        public string CashierName { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalFine { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
