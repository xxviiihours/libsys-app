using Caliburn.Micro;
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

        private string _emailAddress;
        private string _password;
        public LoginViewModel()
        {

        }

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
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

        public void Login()
        {
            Console.WriteLine("");
        }
    }
}
