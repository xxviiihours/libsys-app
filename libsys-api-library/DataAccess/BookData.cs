﻿using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class BookData
    {
        private readonly IConfiguration configuration;

        public BookData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<BookModel> GetAllBooks()
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);

            var output = sql.LoadData<BookModel, dynamic>("dbo.spGetAllBookInfo", new { }, "libsys_data");
            return output;
        }

        public List<BookModel> GetAllAvailableBooks()
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);

            var output = sql.LoadData<BookModel, dynamic>("dbo.spGetAllAvailableBookInfo", new { }, "libsys_data");
            return output;
        }

        public void SaveBookInfo(BookModel bookModel)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            sql.SaveData("dbo.spInsertBookInfo", bookModel, "libsys_data");
        }

        public BookModel GetBookById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            BookModel books = new BookModel();
            var param = new { Id = Id };

            var output = sql.LoadData<BookModel, dynamic>("dbo.spBookInfoLookup", param, "libsys_data");
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
            SqlDataAccess sql = new SqlDataAccess(configuration);
            BookModel bookDetail = new BookModel();
            var param = new { Title = BookTitle };

            var output = sql.LoadData<BookModel, dynamic>("dbo.spAvailableBookInfoLookup", param, "libsys_data");
            
            return output;
        }

        public List<BookModel> GetAllBooksByTitle(string bookTitle)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            var param = new { Title = bookTitle };

            var output = sql.LoadData<BookModel, dynamic>("dbo.spGetAllBookByTitle", param, "libsys_data");
            return output;
        }

        public void UpdateBookInfo(int Id, BookModel bookModel)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
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
            sql.UpdateData<BookModel, dynamic>("dbo.spUpdateBookInfo", param, "libsys_data");
        }

        public void DeleteBookInfo(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            var param = new { Id = Id };
            sql.DeleteData("dbo.spDeleteBookInfo", param, "libsys_data");
        }
    }
}
