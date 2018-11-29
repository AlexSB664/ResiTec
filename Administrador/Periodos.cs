using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatizacionResidencias;
namespace Administrador
{
    public partial class Periodos : Form
    {
        public static bool periodo = true;
        AutomatizacionResidencias.Acciones.Periodos op = new AutomatizacionResidencias.Acciones.Periodos();
        public List<AutomatizacionResidencias.Periodos> periodos = new List<AutomatizacionResidencias.Periodos>();
        public static BindingSource bin = new BindingSource();
        public Periodos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Errores;
            if (int.TryParse(textBox1.Text, out int Result))
            {
                AutomatizacionResidencias.Periodos a = new AutomatizacionResidencias.Periodos() { año = Result, periodo = periodo };
                if (op.crearperiodo(a, out Errores))
                {
                    MessageBox.Show("Se ha guardado el periodo");

                    string Errore = "";
                    periodos = op.listaperiodos(out Errore);
                    datagrid();
                }
                else
                {
                    MessageBox.Show(Errores);
                }
            }
            else
            {
                MessageBox.Show("Año invalido");
            }



            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            periodo = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            periodo = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void datagrid()
        {
            var bindingList = new BindingList<AutomatizacionResidencias.Periodos>(periodos);


            var source = new BindingSource(bindingList, null);

            dataGridView1.DataSource = source;
            dataGridView1.Columns["Proyecto_Residencia"].Visible = false;



        }


        private void Periodos_Load(object sender, EventArgs e)
        {
            string Errore = "";
            periodos = op.listaperiodos(out Errore);
            datagrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int i = e.RowIndex; i < e.RowCount + e.RowIndex; i++)
            {
                

            }
        }
    }
}
