using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        private LoginViewModel _loginVieModel;
        public ShellViewModel(LoginViewModel loginViewModel)
        {
            _loginVieModel = loginViewModel;
            ActivateItem(_loginVieModel);

        }
    }
}
