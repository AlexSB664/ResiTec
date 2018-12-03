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


        


        public void crearwordsolicitudresidencia(){


            string destinipath = "Formatos\\" + solicitante.NoControl;
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }

            DocX testTemplate = DocX.Load(@"Templatesformatos\solicitudresidencia.docx");
            //Paragraph p = testTemplate.InsertParagraph("Hello World.");

            DocX testDoc = testTemplate;
            //Paragraph pa = testDoc.InsertParagraph("Foo.");

            testDoc.ReplaceText("{Fecha}",DateTime.Now.Date.ToString());
            testDoc.ReplaceText("{Nombreproyecto}",solicitante.Proyecto_Residencia.Nombre_Proyecto);
            testDoc.ReplaceText("{nombreempresa}",solicitante.Proyecto_Residencia.Nombre_de_la_Empresa);
            testDoc.ReplaceText("{Asesorexterno}",solicitante.Proyecto_Residencia.Nombre_Asesor_Externo);
            testDoc.ReplaceText("{cargoasesor}",solicitante.Proyecto_Residencia.Cargo_Asesor_Externo);
            testDoc.ReplaceText("{asesorexterno}",solicitante.Proyecto_Residencia.Nombre_Asesor_Externo);
            testDoc.ReplaceText("{cargoasesorexterno}", solicitante.Proyecto_Residencia.Cargo_Asesor_Externo);
            testDoc.ReplaceText("{nombrealumno}",solicitante.Nombre + " " + solicitante.Apellido_Paterno + " " + solicitante.Apellido_Materno);
            testDoc.ReplaceText("{Nocontrol}", solicitante.NoControl.ToString());
            testDoc.ReplaceText("{Correoalumno}", solicitante.Correo);
            testDoc.ReplaceText("{telefonoalumno}", solicitante.Telefono);
         

            testDoc.SaveAs(destinipath+@"\Solicitudresidencia" +solicitante.NoControl+".docx");
            testTemplate.Save();

        }




        public void crearwordasignarrevisor()
        {


            string destinipath = "Formatos\\" + solicitante.NoControl;
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }

            DocX testTemplate = DocX.Load(@"Templatesformatos\asignarevisor.docx");
            //Paragraph p = testTemplate.InsertParagraph("Hello World.");

            DocX testDoc = testTemplate;
            //Paragraph pa = testDoc.InsertParagraph("Foo.");

            testDoc.ReplaceText("{nombreproyecto}", solicitante.Proyecto_Residencia.Nombre_Proyecto);

            testDoc.ReplaceText("{Nombrealumno}", solicitante.Nombre + " " + solicitante.Apellido_Paterno + " " + solicitante.Apellido_Materno);
          


            testDoc.SaveAs(destinipath + @"\asignarevisor" + solicitante.NoControl + ".docx");
            testTemplate.Save();

        }

        
        public void crearwordconstanciarevisores()
        {


            string destinipath = "Formatos\\" + solicitante.NoControl;
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }

            DocX testTemplate = DocX.Load(@"Templatesformatos\constanciarevisores.docx");
            //Paragraph p = testTemplate.InsertParagraph("Hello World.");

            DocX testDoc = testTemplate;
            //Paragraph pa = testDoc.InsertParagraph("Foo.");
            try
            {
                testDoc.ReplaceText("{nombrealumno}", solicitante.Nombre + " " + solicitante.Apellido_Paterno + " " + solicitante.Apellido_Materno);
                testDoc.ReplaceText("{nocontrol}", solicitante.NoControl.ToString());
                testDoc.ReplaceText("{nombreproyecto}", solicitante.Proyecto_Residencia.Nombre_Proyecto);
                testDoc.ReplaceText("{nombreempresa}", solicitante.Proyecto_Residencia.Nombre_de_la_Empresa);
                testDoc.ReplaceText("{nombreasesorinterno}", solicitante.Proyecto_Residencia.Asesor_Interno.Nombre);
                testDoc.ReplaceText("{nombreasesorexterno}", solicitante.Proyecto_Residencia.Nombre_Asesor_Externo);
            }
            catch { }



            testDoc.SaveAs(destinipath + @"\constanciarevisores" + solicitante.NoControl + ".docx");
            testTemplate.Save();

        }

        public void crearwordasignacionasesorinterno()
        {


            string destinipath = "Formatos\\" + solicitante.NoControl;
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }

            DocX testTemplate = DocX.Load(@"Templatesformatos\Asignacionasesorinterno.docx");
            //Paragraph p = testTemplate.InsertParagraph("Hello World.");

            DocX testDoc = testTemplate;
            //Paragraph pa = testDoc.InsertParagraph("Foo.");
            try
            {
                testDoc.ReplaceText("{nombrealumno}", solicitante.Nombre + " " + solicitante.Apellido_Paterno + " " + solicitante.Apellido_Materno);
                testDoc.ReplaceText("{correoalumno}", solicitante.Correo);
                testDoc.ReplaceText("{telefonoalumno}", solicitante.Telefono);
                testDoc.ReplaceText("{nombreproyecto}", solicitante.Proyecto_Residencia.Nombre_Proyecto);
                testDoc.ReplaceText("{nombreempresa}", solicitante.Proyecto_Residencia.Nombre_de_la_Empresa);
                testDoc.ReplaceText("{telefonoasesor}", solicitante.Proyecto_Residencia.Telefono_Asesor_Externo);
                testDoc.ReplaceText("{nombreasesor}", solicitante.Proyecto_Residencia.Nombre_Asesor_Externo);
                testDoc.ReplaceText("{cargoasesor}", solicitante.Proyecto_Residencia.Cargo_Asesor_Externo);
            }
            catch { }



            testDoc.SaveAs(destinipath + @"\Asignacionasesorinterno" + solicitante.NoControl + ".docx");
            testTemplate.Save();

        }

        public void crearwordRegistroproyecto()
        {


            string destinipath = "Formatos\\" + solicitante.NoControl;
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }

            DocX testTemplate = DocX.Load(@"Templatesformatos\Registrodeproyecto.docx");
            //Paragraph p = testTemplate.InsertParagraph("Hello World.");

            DocX testDoc = testTemplate;
            //Paragraph pa = testDoc.InsertParagraph("Foo.");
            try
            {
                testDoc.ReplaceText("{fecha}", DateTime.Now.Date.ToString());
                testDoc.ReplaceText("{correoelectronico}", solicitante.Correo);
                testDoc.ReplaceText("{numtelefono}", solicitante.Telefono);
                testDoc.ReplaceText("{nombreproyecto}", solicitante.Proyecto_Residencia.Nombre_Proyecto);
                testDoc.ReplaceText("{nombreestudiante}", solicitante.Nombre +" "+solicitante.Apellido_Paterno+" "+solicitante.Apellido_Materno);
                testDoc.ReplaceText("{numestudiantes}", "1");
                testDoc.ReplaceText("{asesorinterno}", solicitante.Proyecto_Residencia.Asesor_Interno.Nombre);
                testDoc.ReplaceText("{nombreempresa}", solicitante.Proyecto_Residencia.Nombre_de_la_Empresa);
                testDoc.ReplaceText("{nocontrol}", solicitante.NoControl.ToString());
            }
            catch { }



            testDoc.SaveAs(destinipath + @"\Registrodeproyecto" + solicitante.NoControl + ".docx");
            testTemplate.Save();

        }



        public void abrir() {
            string destinipath = "Formatos\\" + solicitante.NoControl;
            if (!Directory.Exists(destinipath))
            {
                Directory.CreateDirectory(destinipath);
            }
            System.Diagnostics.Process.Start(destinipath);
        }

    }
}
