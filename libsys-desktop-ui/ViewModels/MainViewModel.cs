using Caliburn.Micro;
using libsys_desktop_ui_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class MainViewModel : Conductor<object>
    {

        private readonly IUserLoggedInModel userLoggedIn;

        public MainViewModel(IUserLoggedInModel userLoggedIn)
        {
            this.userLoggedIn = userLoggedIn;
        }

        private string _currentUser;

        public string CurrentUser
        {
            get { return _currentUser; }
            set 
            {
                _currentUser = value;
                NotifyOfPropertyChange(() => CurrentUser);
            }
        }

        public void GreetUser()
        {
            CurrentUser = $"Welcome, {userLoggedIn.FirstName}!";
            NotifyOfPropertyChange(() => CurrentUser);
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            GreetUser();
        }
    }
}
