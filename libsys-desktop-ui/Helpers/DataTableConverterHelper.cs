using FastMember;
using libsys_desktop_ui.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Helpers
{
    public class DataTableConverterHelper : IDataTableConverterHelper
    {
        public async Task<DataTable> ConvertToDataTable<T>(BindingList<T> models)
        {
            DataTable table = new DataTable();
            await using (var reader = ObjectReader.Create(models))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
