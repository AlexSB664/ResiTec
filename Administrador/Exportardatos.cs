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
        public List<Tabladatos> datos = new List<Tabladatos>();
        public Exportardatos()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            // dataGridView1.Columns["Proyecto_Residencia"].Visible = false;
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
    }
}
