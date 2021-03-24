using libsys_desktop_ui_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public double GetActualFine()
        {

            string fineText = ConfigurationManager.AppSettings["fine"];

            bool isValidFine = Double.TryParse(fineText, out double output);

            if (isValidFine == false)
            {
                throw new ConfigurationErrorsException("The actual fine is not valid. please set up properly");
            }

            return output;
        }
    }
}
