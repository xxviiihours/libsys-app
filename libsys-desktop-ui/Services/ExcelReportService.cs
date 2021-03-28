using ClosedXML.Excel;
using libsys_desktop_ui.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Services
{
    public class ExcelReportService : IExcelReportService
    {
        public void GenerateExcel(DataTable dataTable, string name)
        {
            var workBook = new XLWorkbook();
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            workBook.Worksheets.Add(dataSet);

            workBook.SaveAs($"{name}.xlsx");
        }
    }
}
