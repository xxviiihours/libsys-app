using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Helpers
{
    public class APIHelper : IAPIHelper
    {

        private readonly IUserLoggedInModel userLoggedIn;

        private HttpClient httpClient;
       
        public HttpClient HttpClient 
        { 
            get 
            { 
                return httpClient; 
            } 
        }
        public APIHelper(IUserLoggedInModel userLoggedIn)
        {
            InitializeClient();
            this.userLoggedIn = userLoggedIn;
        }

        public void InitializeClient()
        {
            string BASE_URL = ConfigurationManager.AppSettings["api"];

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_URL);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)

            });

            using (HttpResponseMessage responseMessage = await httpClient.PostAsync("/token", data))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync("/api/users/id"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<UserLoggedInModel>();
                    userLoggedIn.Id = result.Id;
                    userLoggedIn.FirstName = result.FirstName;
                    userLoggedIn.LastName = result.LastName;
                    userLoggedIn.UserType = result.UserType;
                    userLoggedIn.EmailAddress = result.EmailAddress;

                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public void LogOffUser()
        {
            userLoggedIn.Id = "";
            userLoggedIn.FirstName = "";
            userLoggedIn.LastName = "";
            userLoggedIn.UserType = "";
            userLoggedIn.EmailAddress = "";
            userLoggedIn.CreatedAt = DateTime.MinValue;
        }
    }
}
