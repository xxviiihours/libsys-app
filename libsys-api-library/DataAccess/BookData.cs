using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class BookData
    {
        //private BookModel _books;
        public List<BookDetailModel> GetAllBooks()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<BookDetailModel, dynamic>("spBookInfoLookup", new { }, "libsys-data");
            return output;
        }
        public void SaveBookInfo(BookDetailModel bookModel)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spInsertBookInfo", bookModel, "libsys-data");
        }
        public List<BookDetailModel> GetBookById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var param = new { Id = Id };

            var output = sql.LoadData<BookDetailModel, dynamic>("dbo.spBookInfoLookup", param, "libsys-data");

            return output;
        }
    }
}
