using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatizacionResidencias.Acciones;
using AutomatizacionResidencias;

namespace Administrador
{
    public partial class Exportardatos : Form
    {
        public static Busquedaentablas sug = new Busquedaentablas();
        public List<Tablaperiodo> periodos = new List<Tablaperiodo>();
        public AutomatizacionResidencias.Periodos currentperiodo = new AutomatizacionResidencias.Periodos();
        public Eliminar eliminar= new Eliminar();
        public List<Tabladatos> datos = new List<Tabladatos>();
        public Exportardatos()
        {
            InitializeComponent();


        }


        public void cargarperiodos()
        {
            currentperiodo = sug.periodoactual();
            periodos = sug.periodos();
            periodos.Add(new Tablaperiodo { idperiodo = 0, periodo = "todos" });
            Periodos.DataSource = periodos;
            Periodos.DisplayMember = "periodo";
            Periodos.ValueMember = "idperiodo";
            Periodos.SelectedValue = currentperiodo.Idperiodo;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch {
                MessageBox.Show("Por favor instale excel");
            }
            */
            ImportDataGridViewDataToExcelSheet();

            }







        private void ImportDataGridViewDataToExcelSheet()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs("DATOS" +currentperiodo.periodo+ DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Archivo excel creado en Documentos");
            }
            catch {
                MessageBox.Show("Instale Microsoft Excel para utilizar esta funcion");
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void toolStripMenuItem_ImportDGVToExcel_Click(object sender, EventArgs e)
        {
            ImportDataGridViewDataToExcelSheet();
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

          
        }

        private void Exportardatos_Load(object sender, EventArgs e)
        {
            datos = sug.Exportardatos();


            var bindingList = new BindingList<Tabladatos>(datos);



            var source = new BindingSource(bindingList, null);

            dataGridView1.DataSource = source;
            cargarperiodos();

            // dataGridView1.Columns["Proyecto_Residencia"].Visible = false;
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void Periodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            datos = sug.Exportardatos();

            try
            {
                if (Periodos.Text != "todos")
                {
                    datos = datos.Where(x => x.Periodo_año != null).ToList();
                    datos = datos.Where(x => x.Periodo_año.Contains(Periodos.Text)).ToList();
                }
            }
            catch { }



            var bindingList = new BindingList<Tabladatos>(datos);



            var source = new BindingSource(bindingList, null);

            dataGridView1.DataSource = source;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Errores;


            var confirmResult = MessageBox.Show("Seguro que desea eliminar", "Confirme borrado",
                                  MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (eliminar.Eliminardatosperiodo(datos, out Errores))
                {
                    MessageBox.Show("Datos eliminados");
                    datos = sug.Exportardatos();

                    try
                    {
                        if (Periodos.Text != "todos")
                        {
                            datos = datos.Where(x => x.Periodo_año != null).ToList();
                            datos = datos.Where(x => x.Periodo_año.Contains(Periodos.Text)).ToList();
                        }
                    }
                    catch { }



                    var bindingList = new BindingList<Tabladatos>(datos);



                    var source = new BindingSource(bindingList, null);

                    dataGridView1.DataSource = source;

                }
                else
                {
                    MessageBox.Show(Errores);
                }

            }
                
            
            else
            {
                // If 'No', do something here.
            }








          
        }
    }
}
