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
        public List<BookModel> GetAllBooks()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<BookModel, dynamic>("dbo.spGetAllBookInfo", new { }, "libsys-data");
            return output;
        }

        public List<BookModel> GetAllAvailableBooks()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<BookModel, dynamic>("dbo.spGetAllAvailableBookInfo", new { }, "libsys-data");
            return output;
        }

        public void SaveBookInfo(BookModel bookModel)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spInsertBookInfo", bookModel, "libsys-data");
        }

        public BookModel GetBookById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            BookModel books = new BookModel();
            var param = new { Id = Id };

            var output = sql.LoadData<BookModel, dynamic>("dbo.spBookInfoLookup", param, "libsys-data");
            if(output.Count > 0)
            {
                foreach (var item in output)
                {
                    books = item;
                }
                return books;
            }
            return null;
        }

        public List<BookModel> GetAvailableBooksByTitle(string BookTitle)
        {
            SqlDataAccess sql = new SqlDataAccess();
            BookModel bookDetail = new BookModel();
            var param = new { Title = BookTitle };

            var output = sql.LoadData<BookModel, dynamic>("dbo.spAvailableBookInfoLookup", param, "libsys-data");
            
            return output;
        }

        public void UpdateBookInfo(int Id, BookModel bookModel)
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
            sql.UpdateData<BookModel, dynamic>("dbo.spUpdateBookInfo", param, "libsys-data");
        }

        public void DeleteBookInfo(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var param = new { Id = Id };
            sql.DeleteData("dbo.spDeleteBookInfo", param, "libsys-data");
        }
    }
}
