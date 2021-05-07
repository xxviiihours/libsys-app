using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Services
{
    public class ReportService : IReportService
    {
        private readonly IAPIHelper apiHelper;

        public ReportService(IAPIHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }

        public async Task<List<TransactionModel>> ReportGetAllBorrowedBooks()
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.GetAsync("/api/v2/reports/borrowed-books/"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<TransactionModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task<List<TransactionModel>> ReportGetAllOverduedBooks()
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.GetAsync("/api/v2/reports/overdue/"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<TransactionModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
