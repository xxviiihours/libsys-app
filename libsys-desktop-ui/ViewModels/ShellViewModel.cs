using Caliburn.Micro;
using libsys_desktop_ui.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private MainViewModel _mainViewModel;
        private BookViewModel _bookViewModel;
        private SimpleContainer _container;

        private IEventAggregator _events;
        public ShellViewModel(IEventAggregator events, MainViewModel mainViewModel, BookViewModel bookViewModel,
            SimpleContainer container)
        {
            _events = events;
            _mainViewModel = mainViewModel;
            _bookViewModel = bookViewModel;
            _container = container;

            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_bookViewModel);
        }
    }
}
