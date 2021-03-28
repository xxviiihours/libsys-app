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
        private readonly IUserLoggedInModel user;

        private readonly IEventAggregator events;
        public ShellViewModel(IEventAggregator events, IUserLoggedInModel user,
            IAPIHelper apiHelper)
        {
            this.events = events;
            this.user = user;

            this.events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>());
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
        }

        public async Task LogOut()
        {
            apiHelper.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
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
