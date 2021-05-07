using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Interfaces
{
    public interface IReportService
    {
        Task<List<TransactionModel>> ReportGetAllBorrowedBooks();
        Task<List<TransactionModel>> ReportGetAllOverduedBooks();
    }
}
