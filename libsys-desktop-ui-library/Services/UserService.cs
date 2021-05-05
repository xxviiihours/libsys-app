using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Services
{
    public class UserService : IUserService
    {
        private readonly IAPIHelper apiHelper;
        public UserService(IAPIHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }

        public async Task Save(UserModel userModel)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.PostAsJsonAsync("/api/v2/users/save", userModel))
            {
                if (responseMessage.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
