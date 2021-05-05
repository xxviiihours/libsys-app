using Caliburn.Micro;
using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class UserViewModel : Screen
    {

        private readonly IAPIHelper apiHelper;
        private readonly IUserService userService;

        public UserViewModel(IAPIHelper apiHelper, IUserService userService)
        {
            this.apiHelper = apiHelper;
            this.userService = userService;
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value;

                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set 
            { 
                lastName = value;

                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        public BindingList<string> UserTypes
        {
            get
            {
                return new BindingList<string>(
                  new string[] { "ADMIN", "STAFF" });

            }
        }

        private string selectedUserType;
        public string SelectedUserType
        {
            get { return selectedUserType; }
            set
            {
                selectedUserType = value;
                NotifyOfPropertyChange(() => SelectedUserType);
            }
        }

        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set 
            { 
                emailAddress = value;

                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;

                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyOfPropertyChange(() => Message);
                NotifyOfPropertyChange(() => IsMessageVisible);
            }
        }

        private string messageColor;

        public string MessageColor
        {
            get { return messageColor; }
            set 
            { 
                messageColor = value;
                NotifyOfPropertyChange(() => MessageColor);
            }
        }

        public bool IsMessageVisible
        {
            get
            {
                bool output = false;
                if (Message?.Length > 0)
                {
                    output = true;
                    return output;
                }
                return output;
            }
        }
        public bool CanRegister
        {
            get
            {
                bool option = false;
                if (FirstName?.Length > 0 &&
                    LastName?.Length > 0 &&
                    EmailAddress?.Length > 0 && 
                    Password?.Length > 0)
                {
                    option = true;
                    return option;
                }

                return option;
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                NotifyOfPropertyChange(() => IsLoading);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        public async Task Register()
        {
            try
            {
                Message = "";
                IsLoading = true;
                var result = await apiHelper.Authenticate(EmailAddress, Password);

                UserModel userModel = new UserModel
                {
                    Id = result.Id,
                    FirstName = FirstName,
                    LastName = LastName,
                    UserType = SelectedUserType,
                    EmailAddress = result.UserName,
                    CreatedAt = DateTime.Now

                };

                await userService.Save(userModel);
                IsLoading = false;
                MessageColor = "#00c853";
                Message = "Successfully Registered. You can close this form.";
                Clear();
            }
            catch (Exception ex)
            {
                if( ex.Message == "Bad Request")
                {
                    MessageColor = "#ef5350";
                    Message = "We can't find the email address you've provided. Try again later.";
                    IsLoading = false;
                }
                else
                {
                    MessageColor = "#ef5350";
                    Message = "Email address is already taken. Please use a different one.";
                    IsLoading = false;
                }
            }
        }

        private void Clear()
        {
            Message = "";
            FirstName = "";
            LastName = "";
            SelectedUserType = null;
            EmailAddress = "";
            Password = "";
        }

    }
}
