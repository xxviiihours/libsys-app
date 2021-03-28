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
    public class BookClassificationService : IBookClassificationService
    {
        private readonly IAPIHelper apiHelper;
        public BookClassificationService(IAPIHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }

        public async Task<List<BookClassificationModel>> GetAll()
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.GetAsync("/api/v2/book-classification"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<BookClassificationModel>>();
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
