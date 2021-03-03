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

        private IAPIHelper _apiHelper;
        IEventAggregator _events;

        private string _emailAddress;
        private string _password;

        private string _errorMessage;


        public LoginViewModel(IAPIHelper aPIHelper, IEventAggregator events)
        {
            _apiHelper = aPIHelper;
            _events = events;
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);

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
                var userAuth = await _apiHelper.Authenticate(EmailAddress, Password);
                await _apiHelper.GetLoggedInUserInfo(userAuth.Access_Token);

                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMessage = ex.Message + ": " + "Invalid Username or password.";
            }
        }
    }
}
