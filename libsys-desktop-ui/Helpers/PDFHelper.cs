using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Helpers
{
    public class PDFHelper : IPDFHelper
    {

        public void GenerateReport(string content)
        {
            PdfDocument document = new PdfDocument();


            document.Info.Title = "Violation Receipt";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XTextFormatter xText = new XTextFormatter(gfx);

            // Create a font
            XFont font = new XFont("OCR A Extended", 12);

            XRect rect = new XRect(10, 10, 240, page.Height);
            // Draw the text
            xText.DrawString(content, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            // Save the document...
            const string filename = "Violation Receipt.pdf";
            document.Save(filename);

            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}
