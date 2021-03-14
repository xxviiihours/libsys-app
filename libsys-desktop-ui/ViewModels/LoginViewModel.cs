using Caliburn.Micro;
using libsys_desktop_ui.EventHandlers;
using libsys_desktop_ui_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class LoginViewModel : Screen
    {

        private readonly IAPIHelper apiHelper;
        private readonly IEventAggregator events;

        private string emailAddress = "admin@libsysapp.com";
        private string password = "@Dmin123";

        private string errorMessage;


        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            this.apiHelper = apiHelper;
            this.events = events;
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanLogin);
                NotifyOfPropertyChange(() => IsDisabled);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
                NotifyOfPropertyChange(() => IsDisabled);
            }
        }
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => IsDisabled);
            }
        }

        public bool IsErrorVisible
        {
            get 
            {
                bool output = false;
                if(ErrorMessage?.Length > 0)
                {
                    output = true;
                    return output;
                }
                return output; 
            }
        }

        public string IsDisabled 
        {
            get 
            {
                if (CanLogin)
                {
                    return "White";
                }

                return "Black";
            }
        }



        public bool CanLogin 
        {
            get
            {
                bool option = false;
                if(EmailAddress?.Length > 0 && Password?.Length > 0)
                {
                    option = true;
                    return option;
                }

                return option;
            }
        }

        public async Task Login()
        {
            try
            {
                ErrorMessage = "";
                var userAuth = await apiHelper.Authenticate(EmailAddress, Password);
                await apiHelper.GetLoggedInUserInfo(userAuth.Access_Token);

                events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMessage = ex.Message + ": " + "Invalid Username or password.";
            }
        }
    }
}
