using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizacionResidencias;
using AutomatizacionResidencias.Acciones;
namespace Administrador
{
    public partial class Administradorprincipal : Form
    {

        public static Busquedaentablas sug = new Busquedaentablas();
        public static List<Tablaproyecto> proyectos = new List<Tablaproyecto>();
        public static List<TablaAlumno> alumnos = new List<TablaAlumno>();

        public Administradorprincipal()
        {
            InitializeComponent();
        }

        private void Administradorprincipal_Load(object sender, EventArgs e)
        {


          
            // TODO: esta línea de código carga datos en la tabla 'proyectosdeResidencia.Proyecto_Residencia' Puede moverla o quitarla según sea necesario.
            /*
            this.proyecto_ResidenciaTableAdapter.Fill(this.proyectosdeResidencia.Proyecto_Residencia);
            */
        }

        public void alumno() {
            alumnos = sug.Alumnos();

            var bindingList = new BindingList<TablaAlumno>(alumnos);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        public void proyecto(){
            proyectos = sug.proyectosregistrados();
            var status = sug.statusdeproyectos();
            var bindingList = new BindingList<Tablaproyecto>(proyectos);

            var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;


            DataGridViewComboBoxColumn ColumnMonth = new DataGridViewComboBoxColumn();
            ColumnMonth.DataPropertyName = "status";
            ColumnMonth.HeaderText = "status";
            ColumnMonth.Width = 120;
            ColumnMonth.DataSource = bindingSourceMonth;
            ColumnMonth.ValueMember = "IdStatus";
            ColumnMonth.DisplayMember = "nombre";
            dataGridView1.Columns["Status"].Visible=false;
            dataGridView1.Columns.Add(ColumnMonth);

        }


        private void OnGridDefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Status status = new Status();
            status.Show();

        }


        private void cmbboxClr_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.FillRectangle(b, rect.X, rect.Y, rect.Width, rect.Height);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void proyectosresidencia_Click(object sender, EventArgs e)
        {
            proyecto();
        }

        private void datosdealumno_Click(object sender, EventArgs e)
        {
            alumno();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Formatos formatos = new Formatos();
            formatos.Show();
        }
    }
}
