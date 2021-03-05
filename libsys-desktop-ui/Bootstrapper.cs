using Caliburn.Micro;
using libsys_desktop_ui.Helpers;
using libsys_desktop_ui.ViewModels;
using libsys_desktop_ui_library.Helpers;
using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using libsys_desktop_ui_library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace libsys_desktop_ui
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty, "Password", "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container)
                .PerRequest<IBookService, BookService>()
                .PerRequest<IBookClassificationService, BookClassificationService>();

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IUserLoggedInModel, UserLoggedInModel>()
                .Singleton<IAPIHelper, APIHelper>();
            
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(classType => classType.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
