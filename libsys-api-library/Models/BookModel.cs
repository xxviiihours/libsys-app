using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace libsys_api_library.Models
{
    public class BookModel
    {
        public List<BookDetailModel> BookDetails { get; set; } = new List<BookDetailModel>();

    }
}