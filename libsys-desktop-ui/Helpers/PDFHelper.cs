using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using libsys_desktop_ui.Interfaces;
using Microsoft.Win32;

using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace libsys_desktop_ui.Helpers
{
    public class PDFHelper : IPDFHelper
    {

        public void GenerateReport(string content, string filename, PdfFont fontFamily)
        {
            //var document = new PdfDocument();


            //document.Info.Title = filename;

            //// Create an empty page
            //var page = document.AddPage();

            //// Get an XGraphics object for drawing
            //var gfx = XGraphics.FromPdfPage(page);

            //var xText = new XTextFormatter(gfx);

            //// Create a font
            //var font = new XFont(fontFamily, 12);

            //XRect rect = new XRect(10, 10, 340, page.Height);
            //// Draw the text
            //xText.DrawString(content, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            //// Save the document...
            //string fileType = $"{filename}.pdf";
            //var saveFile = new SaveFileDialog();
            //File.WriteAllBytes(saveFile.SafeFileName, document);
            //document.Save(fileType);

            var fileDialog = new SaveFileDialog
            {
                Filter = "PDF Document|*.pdf",
                Title = "Save a PDF File"
            };
            fileDialog.ShowDialog();

            using FileStream stream = new FileStream(fileDialog.FileName, FileMode.Create);
            var pdfWriter = new PdfWriter(stream);
            var pdfDoc = new PdfDocument(pdfWriter);
            var doc = new Document(pdfDoc);
            var paragraph = new Paragraph();
            var text = new Text(content);
            text.SetFont(fontFamily);

            paragraph.Add(text);

            doc.Add(paragraph);
            doc.Close();
            //Font font = new Font();
            //var text = new Text
            //var raw = new Paragraph(content);
            //font.SetFamily(fontFamily);
            //PdfWriter.GetInstance(pdfDoc, stream);
            //pdfDoc.Open();
            //pdfDoc.Add(raw);
            pdfDoc.Close();
            stream.Close();
            // ...and start a viewer.

        }
    }
}
