using libsys_desktop_ui_library.Models;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Interfaces
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}