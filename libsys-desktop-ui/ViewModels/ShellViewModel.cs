using Caliburn.Micro;
using libsys_desktop_ui.EventHandlers;
using libsys_desktop_ui_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IAPIHelper apiHelper;
        private readonly IWindowManager window;
        private readonly UserViewModel userViewModel;
        private readonly IUserLoggedInModel user;

        private readonly IEventAggregator events;
        public ShellViewModel(IEventAggregator events, IUserLoggedInModel user,
            IAPIHelper apiHelper, IWindowManager window, UserViewModel userViewModel)
        {
            this.events = events;
            this.user = user;

            this.events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>());
            this.apiHelper = apiHelper;
            this.window = window;
            this.userViewModel = userViewModel;
        }

        public bool IsUserLoggedIn
        {
            get
            {
                bool output = false;
                if (string.IsNullOrWhiteSpace(user.Id) == false &&
                    ShowLogin == false)
                {
                    output = true;
                    return output;
                }
                return output;
            }
        }

        public bool ShowLogin
        {
            get
            {
                bool output = false;
                if (string.IsNullOrWhiteSpace(user.Id) == true)
                {
                    output = true;
                    return output;
                }
                return output;
            }
        }

        public void ExitApplication()
        {
            TryCloseAsync();
        }

        //public void Handle(LogOnEvent message)
        //{
        //    ActivateItem(IoC.Get<MainViewModel>());
        //    NotifyOfPropertyChange(() => IsUserLoggedIn);
        //}
        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {

            await ActivateItemAsync(IoC.Get<MainViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
            NotifyOfPropertyChange(() => ShowLogin);
        }
        public async Task Login()
        {
            await ActivateItemAsync(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
        }
        public async Task Register()
        {
            await window.ShowDialogAsync(userViewModel, null, null);
        }

        public async Task LogOut()
        {
            apiHelper.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
            NotifyOfPropertyChange(() => ShowLogin);
        }

        public async Task ManageBooks()
        {
            await ActivateItemAsync(IoC.Get<BookViewModel>());
        }

        public async Task ManageStudents()
        {
            await ActivateItemAsync(IoC.Get<StudentViewModel>());
        }

        public async Task ManageBorrowBooks()
        {
            await ActivateItemAsync(IoC.Get<BorrowViewModel>());
        }

        public async Task ManageReturnBooks()
        {
            await ActivateItemAsync(IoC.Get<ReturnViewModel>());
        }

        public void ManageReports()
        {
            //TODO: Create a Manage Report form
        }

        public async Task ReturnDashboard()
        {
            await ActivateItemAsync(IoC.Get<MainViewModel>());
        }

    }
}
