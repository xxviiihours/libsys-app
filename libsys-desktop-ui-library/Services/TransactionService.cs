using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Services
{
   public class TransactionService : ITransactionService
    {
        private readonly IAPIHelper _apiHelper;
        public TransactionService(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task Save(BorrowListModel borrowList)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.HttpClient.PostAsJsonAsync("/api/transaction/borrow/save", borrowList))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    //TODO Create notification
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
