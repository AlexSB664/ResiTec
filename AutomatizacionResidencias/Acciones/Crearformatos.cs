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
            string destinipath = "Formatos\\"+solicitante.NoControl+"\\";
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }
            StringWriter sw = new StringWriter();
            sw.WriteLine(createhtmlbody(html));
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document();
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, new FileStream(destinipath+"formato1.pdf", FileMode.Create));
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
        }



        private string createhtmlbody(string htmltamplate)

        {

            string body = string.Empty;

            using (StreamReader reader = new StreamReader("Templatesformatos/" + htmltamplate + ".html"))

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
