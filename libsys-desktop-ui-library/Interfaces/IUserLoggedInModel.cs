using System;

namespace libsys_desktop_ui_library.Interfaces
{
    public interface IUserLoggedInModel
    {
        DateTime CreatedAt { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string UserType { get; set; }
    }
}