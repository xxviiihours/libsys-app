using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class TransactionData
    {
        private readonly IConfiguration configuration;

        public TransactionData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SaveBorrowInfo(BorrowListModel borrowList)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            List<TransactionModel> borrowDetails = new List<TransactionModel>();
            BookData books = new BookData(configuration);
            StudentData students = new StudentData(configuration);

            foreach(var item in borrowList.BorrowedBookDetails)
            {
                var detail = new TransactionModel
                {
                    BookId = item.BookId,
                    CallNumber = item.CallNumber,
                    BookTitle = item.BookTitle,
                    UserId = item.UserId,
                    ClassificationId = item.ClassificationId,
                    ClassificationType = item.ClassificationType,
                    Status = item.Status,
                    DateBorrowed = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
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

        public List<TransactionModel> GetBorrowedBooksByClassificationId(string classificationId)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            var param = new { ClassificationId = classificationId };

            var output = sql.LoadData<TransactionModel, dynamic>("dbo.spBorrowedBooksLookup", param, "libsys-data");

            return output;
        }

        public void Return(int id, TransactionModel borrowedBook)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            var param = new
            {
                BookId = borrowedBook.BookId,
                CallNumber = borrowedBook.CallNumber,
                ClassificationId = borrowedBook.ClassificationId,
                Status = borrowedBook.Status,
                Id = id
            };
            sql.UpdateData<TransactionModel, dynamic>("dbo.spReturnBookInfo", param, "libsys-data");
        }
    }
}
