using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace UrlRewritingForShowPDF
{
    public partial class ShowPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlParam = Request.QueryString["Category"];
            if (!string.IsNullOrEmpty(urlParam))
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "PDFsharp Clock Demo";
                document.Info.Author = "Stefan Lange";
                document.Info.Subject = "Server time: " + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Create an empty page
                PdfPage page = document.AddPage();

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create a font
                XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

                // Draw the text
                gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

                // Draw the text
                gfx.DrawString(urlParam, font, XBrushes.Red, new XRect(0, 20, page.Width, page.Height), XStringFormats.Center);

                // Send PDF to browser
                using (MemoryStream stream = new MemoryStream())
                {
                    document.Save(stream, false);
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", stream.Length.ToString());
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    stream.Close();
                    Response.End();
                }
            }
            else
            {
                this.labMsg.Text = "There is no parameter.";
            }
        }
    }
}