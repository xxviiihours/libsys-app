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

            var output = sql.LoadData<BookDetailModel, dynamic>("dbo.spGetAllBookInfo", new { }, "libsys-data");
            return output;
        }

        public List<BookDetailModel> GetAllAvailableBooks()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<BookDetailModel, dynamic>("dbo.spGetAllAvailableBookInfo", new { }, "libsys-data");
            return output;
        }

        public void SaveBookInfo(BookDetailModel bookModel)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spInsertBookInfo", bookModel, "libsys-data");
        }

        public BookDetailModel GetBookById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            BookDetailModel bookDetail = new BookDetailModel();
            var param = new { Id = Id };

            var output = sql.LoadData<BookDetailModel, dynamic>("dbo.spBookInfoLookup", param, "libsys-data");
            if(output.Count > 0)
            {
                foreach (var item in output)
                {
                    bookDetail = item;
                }
                return bookDetail;
            }
            return null;
        }

        public List<BookDetailModel> GetAvailableBooksByTitle(string BookTitle)
        {
            SqlDataAccess sql = new SqlDataAccess();
            BookDetailModel bookDetail = new BookDetailModel();
            var param = new { Title = BookTitle };

            var output = sql.LoadData<BookDetailModel, dynamic>("dbo.spAvailableBookInfoLookup", param, "libsys-data");
            
            return output;
        }

        public void UpdateBookInfo(int Id, BookDetailModel bookModel)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var param = new
            {
                CallNumber = bookModel.CallNumber,
                Classification = bookModel.Classification,
                Title = bookModel.Title,
                Description = bookModel.Description,
                Edition = bookModel.Edition,
                Volumes = bookModel.Volumes,
                Pages = bookModel.Pages,
                Source = bookModel.Source,
                Price = bookModel.Price,
                Publisher = bookModel.Publisher,
                Location = bookModel.Location,
                Year = bookModel.Year,
                Author = bookModel.Author,
                ModifiedBy = bookModel.ModifiedBy,
                LastModified = bookModel.LastModified,

                Id = Id
            };
            sql.UpdateData<BookDetailModel, dynamic>("dbo.spUpdateBookInfo", param, "libsys-data");
        }

        public void DeleteBookInfo(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var param = new { Id = Id };
            sql.DeleteData("dbo.spDeleteBookInfo", param, "libsys-data");
        }
    }
}
