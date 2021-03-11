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

        private BookViewModel _bookViewModel;
        private StudentViewModel _studentViewModel;

        private IUserLoggedInModel _userLoggedIn;

        public MainViewModel(IUserLoggedInModel userLoggedIn, BookViewModel bookViewModel, StudentViewModel studentViewModel)
        {
            _userLoggedIn = userLoggedIn;
            _bookViewModel = bookViewModel;
            _studentViewModel = studentViewModel;
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
            CurrentUser = $"Welcome, {_userLoggedIn.FirstName}!";
            NotifyOfPropertyChange(() => CurrentUser);
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            GreetUser();
        }
    }
}
