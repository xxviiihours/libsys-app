using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Models
{
    public class BorrowItemModel
    {
        public int Id { get; set; }

        public BookModel Book { get; set; }

        public string ClassificationId { get; set; }

        public string ClassificationType { get; set; }

        public string Status { get; set; }

        public DateTime DateBorrowed { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
