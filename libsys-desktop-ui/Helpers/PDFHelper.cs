using libsys_desktop_ui.Interfaces;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;

namespace libsys_desktop_ui.Helpers
{
    public class PDFHelper : IPDFHelper
    {

        public void GenerateReport(string content)
        {
            var document = new PdfDocument();


            document.Info.Title = "Violation Receipt";

            // Create an empty page
            var page = document.AddPage();

            // Get an XGraphics object for drawing
            var gfx = XGraphics.FromPdfPage(page);

            var xText = new XTextFormatter(gfx);

            // Create a font
            var font = new XFont("OCR A Extended", 12);

            XRect rect = new XRect(10, 10, 240, page.Height);
            // Draw the text
            xText.DrawString(content, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            // Save the document...
            const string filename = "Violation Receipt.pdf";
            document.Save(filename);

            // ...and start a viewer.
        }
    }
}
