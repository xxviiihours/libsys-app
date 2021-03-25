using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Interfaces
{
    public interface IExcelReportService
    {
        void GenerateExcel(DataTable datatable, string path);
    }

}
