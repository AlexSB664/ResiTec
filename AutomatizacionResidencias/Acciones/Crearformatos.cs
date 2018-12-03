using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using System.Data;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using iText.Html2pdf;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.parser;
using Xceed.Words.NET;
using Paragraph = Xceed.Words.NET.Paragraph;

namespace AutomatizacionResidencias
{
    public class Crearformatos
    {
        public static string outpath;
        public static Alumno solicitante;


        public void establecer(Alumno sol) {

            solicitante = sol;
        }
        public void Reporte(DataGridView dataGridView1)
        {

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                    catch
                    {
                        pdfTable.AddCell("Vacio");

                    }
                }
            }
            //Exporting to PDF
            string folderPath = "Reportes\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            outpath = folderPath + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Minute + DateTime.Now.Second + "Reporte.pdf";
            using (FileStream stream = new FileStream(outpath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            System.Diagnostics.Process.Start(outpath);

        }


        public void HTMLToPDF(string html)
        {
            string destinipath = "Formatos\\" + solicitante.NoControl;
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }
            /*
            StringWriter sw = new StringWriter();
            sw.WriteLine(createhtmlbody(html));
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document();
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, new FileStream(destinipath+"formato1.pdf", FileMode.Create));
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            */

            ConverterProperties properties = new ConverterProperties();
            properties.SetBaseUri(html);
            var cssText = System.IO.File.ReadAllText(html + @"\main.css");
            //var htmlText = System.IO.File.ReadAllText(html + @"\Formato de registro de proyecto para titulacion integral (anexo 1) ITT-AC-PO-008-01 (2).html");
            // HtmlConverter.ConvertToPdf(htmlText, new FileStream(destinipath+"\\Formatoregistro.pdf",FileMode.Create));
            var htmlText = createhtmlbody(html);
            /*
            using (var css = new MemoryStream()) {
                using (var htmlStream = new StringReader((htmlText)))
                {

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var document = new Document())
                        {
                            PdfWriter writer = PdfWriter.GetInstance(
                                document, memoryStream
                            );
                            document.Open();
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlStream);
                        }
                        File.WriteAllBytes(destinipath + "\\Formatoregistro.pdf", memoryStream.ToArray());
                    }

                }
            }
            */




        }

        public void ConvertHtmlToPdf(string xHtml)
        {
            string destinipath = "Formatos\\" + solicitante.NoControl;
            var htmlText = createhtmlbody(xHtml);

            // var cssText = System.IO.File.ReadAllText(xHtml + @"\main.css");
            var cssText = "";
            using (var stream = new FileStream(destinipath + "\\Formatoregistro.pdf", FileMode.Create))
            {
                using (var document = new Document())
                {
                    var writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    // instantiate custom tag processor and add to `HtmlPipelineContext`.
                    var tagProcessorFactory = Tags.GetHtmlTagProcessorFactory();

                    var htmlPipelineContext = new HtmlPipelineContext(null);
                    htmlPipelineContext.SetTagFactory(tagProcessorFactory);

                    var pdfWriterPipeline = new PdfWriterPipeline(document, writer);
                    var htmlPipeline = new HtmlPipeline(htmlPipelineContext, pdfWriterPipeline);

                    // get an ICssResolver and add the custom CSS
                    var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true);
                    cssResolver.AddCss(cssText, "utf-8", true);
                    var cssResolverPipeline = new CssResolverPipeline(
                        cssResolver, htmlPipeline
                    );

                    var worker = new XMLWorker(cssResolverPipeline, true);
                    var parser = new XMLParser(worker);
                    using (var stringReader = new StringReader(htmlText))
                    {
                        parser.Parse(stringReader);
                    }
                }
            }
        }

        public void crearword(){
            DocX testTemplate = DocX.Load(@"Templatesformatos\ITT-AC-PO-007-03 FORMATO PARA ASIGNACION DE ASESOR INTRNO DE RESIDENCIAS PROFESIONALES (2).doc");
            //Paragraph p = testTemplate.InsertParagraph("Hello World.");

            DocX testDoc = testTemplate;
            //Paragraph pa = testDoc.InsertParagraph("Foo.");

            testDoc.SaveAs(@"Templatesformatos\test2.docx");
            testTemplate.Save();

        }


        private string createhtmlbody(string htmltamplate)

        {

            string body = string.Empty;

            using (StreamReader reader = new StreamReader(@"Templatesformatos\1-FormatoDeRegistro\Formato de registro de proyecto para titulacion integral (anexo 1) ITT-AC-PO-008-01 (2).html"))

            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{nombre}", solicitante.Nombre);
            body = body.Replace("{apellido paterno}", solicitante.Apellido_Paterno );
            body = body.Replace("{apellido materno}", solicitante.Apellido_Materno);



            return body;

        }
    }
}
