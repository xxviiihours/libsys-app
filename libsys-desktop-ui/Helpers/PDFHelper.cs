using libsys_desktop_ui.Interfaces;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System.Diagnostics;

namespace libsys_desktop_ui.Helpers
{
    public class PDFHelper : IPDFHelper
    {

        public void GenerateReport(string content, string filename, string fontFamily)
        {
            var document = new PdfDocument();


            document.Info.Title = filename;

            // Create an empty page
            var page = document.AddPage();

            // Get an XGraphics object for drawing
            var gfx = XGraphics.FromPdfPage(page);

            var xText = new XTextFormatter(gfx);

            // Create a font
            var font = new XFont(fontFamily, 12);

            XRect rect = new XRect(10, 10, 340, page.Height);
            // Draw the text
            xText.DrawString(content, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            // Save the document...
            string fileType = $"{filename}.pdf";
            document.Save(fileType);

            // ...and start a viewer.

        }
    }
}
