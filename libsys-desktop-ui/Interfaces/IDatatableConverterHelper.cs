using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Interfaces
{
    public interface IDataTableConverterHelper
    {
        Task<DataTable> ConvertToDataTable<T>(BindingList<T> models);
    }

}
