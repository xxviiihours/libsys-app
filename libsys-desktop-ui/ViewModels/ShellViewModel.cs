using Caliburn.Micro;
using libsys_desktop_ui.EventHandlers;
using libsys_desktop_ui_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IAPIHelper apiHelper;
        private readonly IUserLoggedInModel user;

        private readonly IEventAggregator events;
        public ShellViewModel(IEventAggregator events, IUserLoggedInModel user,
            IAPIHelper apiHelper)
        {
            this.events = events;
            this.user = user;

            this.events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
            this.apiHelper = apiHelper;
        }

        public bool IsUserLoggedIn
        {
            get
            {
                bool output = false;
                if (string.IsNullOrWhiteSpace(user.Id) == false)
                {
                    output = true;
                    return output;
                }
                return output;
            }
        }

        public void ExitApplication()
        {
            TryClose();
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(IoC.Get<MainViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
        }
        
        public void LogOut()
        {
            apiHelper.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
        }

        public void ManageBooks()
        {
            ActivateItem(IoC.Get<BookViewModel>());
        }

        public void ManageStudents()
        {
            ActivateItem(IoC.Get<StudentViewModel>());
        }

        public void ManageBorrowBooks()
        {
            ActivateItem(IoC.Get<BorrowViewModel>());
        }

        public void ManageReturnBooks()
        {
            ActivateItem(IoC.Get<ReturnViewModel>());
        }

        public void ManageReports()
        {
            //TODO: Create a Manage Report form
        }

        public void ReturnDashboard()
        {
            ActivateItem(IoC.Get<MainViewModel>());
        }
    }
}
