using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Interfaces
{
    public interface IBookService
    {
        Task<List<BookModel>> GetAllBooks();
        Task<List<BookModel>> GetAllAvailableBooks();
        Task<BookModel> GetByBookId(string bookId);
        Task<BookModel> GetByBookTitle(string bookTitle);
        Task Save(BookModel bookModel);
    }
}
