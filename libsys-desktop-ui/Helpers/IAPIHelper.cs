using libsys_desktop_ui.Models;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}