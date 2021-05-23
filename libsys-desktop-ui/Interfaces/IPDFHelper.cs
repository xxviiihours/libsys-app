using iText.Kernel.Font;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Interfaces
{
    public interface IPDFHelper
    {
        void GenerateReport(string content, string filename, PdfFont fontFamily);
    }
}
