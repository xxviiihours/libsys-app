using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.Models
{
    public class BookDetailModel
    {
        public int Id { get; set; }
        public string CallNumber { get; set; }
        public string Classification { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Edition { get; set; }
        public int Volumes { get; set; }
        public int Pages { get; set; }
        public string Source { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public string Location { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime LastModified { get; set; }
    }
}
