using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Interfaces
{
    public interface ITransactionService
    {
        Task Borrow(BorrowListModel borrowList);
        Task<List<TransactionModel>> GetBorrowedBooksByClassificationId(string studentId);
        Task Return(int id, TransactionModel transactionModel);
    }
}
