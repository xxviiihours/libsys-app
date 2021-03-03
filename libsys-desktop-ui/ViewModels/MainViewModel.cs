using Caliburn.Micro;
using libsys_desktop_ui_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class MainViewModel : Screen
    {

        private string _currentUser;
        private IUserLoggedInModel _userLoggedIn;

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            CurrentUser = "Welcome, " + _userLoggedIn.FirstName + "!";
        }
        public MainViewModel(IUserLoggedInModel userLoggedIn)
        {
            _userLoggedIn = userLoggedIn;
        }

        public string CurrentUser
        {
            get 
            { 
                return _currentUser; 
            }
            set 
            { 
                _currentUser = value;
                NotifyOfPropertyChange(() => CurrentUser);
            }
        }

        public void ManageBooks()
        {
            Console.WriteLine("Hello World!");
        }

        public void ManageStudents()
        {
            //TODO: Create a Manage student form
        }

        public void ManageFaculty()
        {
            //TODO: Create a Manage Faculty form
        }

        public void ManageTransactions()
        {
            //TODO: Create a Manage Transaction form
        }

        public void ManageReports()
        {
            //TODO: Create a Manage Report form
        }

        public void ManageSettings()
        {
            //TODO: Create a Manage Settings form
        }

    }
}
