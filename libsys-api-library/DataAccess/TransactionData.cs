using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class TransactionData
    {
        public void SaveBorrowInfo(BorrowListModel borrowList)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<BorrowModel> borrowDetails = new List<BorrowModel>();
            BookData books = new BookData();
            StudentData students = new StudentData();

            foreach(var item in borrowList.BorrowedBookDetails)
            {
                var detail = new BorrowModel
                {
                    BookId = item.BookId,
                    CallNumber = item.CallNumber,
                    UserId = item.UserId,
                    ClassificationId = item.ClassificationId,
                    ClassificationType = item.ClassificationType,
                    Status = item.Status,
                    DateBorrowed = item.DateBorrowed,
                    DueDate = item.DueDate,
                    CreatedAt = item.CreatedAt
                };
                var bookInfo = books.GetBookById(detail.BookId);

                if(bookInfo == null)
                {
                    throw new Exception("Book ID not found");
                }

                var studentInfo = students.GetStudentById(detail.ClassificationId);

                if(studentInfo == null)
                {
                    throw new Exception("Student ID not found");
                }

                borrowDetails.Add(detail);
            }
          
            sql.SaveData("dbo.spInsertBorrowTransaction", borrowDetails, "libsys-data");
        }
    }
}
