using libsys_desktop_ui_library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Interfaces
{
    public interface IAPIHelper
    {
        HttpClient HttpClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}