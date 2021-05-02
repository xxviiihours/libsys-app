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
    public class ViolationService : IViolationService
    {
        private readonly IAPIHelper apiHelper;

        public ViolationService(IAPIHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }

        public async Task Save(ViolationModel violationModel)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.PostAsJsonAsync("/api/v2/violations/save", violationModel))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    // Create Logger here.
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}