﻿using System;
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
        AgendarExpo ag = new AgendarExpo();

        Reenviarnip re = new Reenviarnip();
        Formatos formatos = new Formatos();

        public static Busquedaentablas sug = new Busquedaentablas();
        public static List<Tablaproyecto> proyectos = new List<Tablaproyecto>();
        public static List<TablaAlumno> alumnos = new List<TablaAlumno>();
        public static List<TablaAsesor> asesores = new List<TablaAsesor>();

        public static bool mostrandoalumno=false;
        public static bool mostrandopryectos=false;
        public static bool mostrandoasesores = false;

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
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void alumno() {

            var bindingList = new BindingList<TablaAlumno>(alumnos);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }


        public void asesor()
        { 
            var bindingList = new BindingList<TablaAsesor>(asesores);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        public void proyecto(){
           // var status = sug.statusdeproyectos();
            var bindingList = new BindingList<Tablaproyecto>(proyectos);

            //var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;


            DataGridViewComboBoxColumn ColumnMonth = new DataGridViewComboBoxColumn();
            ColumnMonth.DataPropertyName = "status";
            ColumnMonth.HeaderText = "status";
            ColumnMonth.Width = 120;
            //ColumnMonth.DataSource = bindingSourceMonth;
            ColumnMonth.ValueMember = "IdStatus";
            ColumnMonth.DisplayMember = "nombre";
            dataGridView1.Columns["Status"].Visible=false;
            // dataGridView1.Columns.Add(ColumnMonth);
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (row.Cells[11].Value!=null)
                {
                row.DefaultCellStyle.BackColor = Color.FromName(row.Cells[11].Value.ToString()); ;
                    foreach (DataGridViewCell cell in row.Cells) {
                        dataGridView1.Rows[row.Index].Cells[cell.ColumnIndex].Style.ForeColor = Color.White ;
                    }
                }

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
            proyectos = sug.proyectosregistrados();

            proyecto();
            mostrandopryectos = true;
            mostrandoalumno = false;
            mostrandoasesores = false;
            panelproyecto.Visible = true;
            panelasesorinterno.Visible = false;
            Pannelalumno.Visible = false;
            panelproyecto.BringToFront();
            panelasesorinterno.Dock = DockStyle.None;
            Pannelalumno.Dock = DockStyle.None;
            panelproyecto.Dock=DockStyle.Fill;
        }

        private void datosdealumno_Click(object sender, EventArgs e)
        {
            alumnos = sug.Alumnos();

            alumno();
            mostrandopryectos = false;
            mostrandoasesores = false;
            mostrandoalumno = true;
            panelproyecto.Visible = false;
            panelasesorinterno.Visible = false;
            Pannelalumno.Visible = true;

            Pannelalumno.BringToFront();
            panelasesorinterno.Dock = DockStyle.None;
            panelproyecto.Dock = DockStyle.None;
            Pannelalumno.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (formatos.IsDisposed)
            {
                formatos = new Formatos();
            }
            formatos.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

          
                if (mostrandoalumno==true) {
                    Editardatos detallesalumno = new Editardatos(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    detallesalumno.Show();
                }
            if (mostrandopryectos==true) {
                Detallesproyecto de = new Detallesproyecto(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                de.Show();
            }
            if (mostrandoasesores) {
                DetallesAsesorinterno dea = new DetallesAsesorinterno((int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                dea.Show();
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (re.IsDisposed)
            {
                re = new Reenviarnip();
            }
            re.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            asesores = sug.Asesores();

            asesor();
            mostrandopryectos = false;
            mostrandoalumno = false;
            mostrandoasesores = true;
            panelproyecto.Visible = false;
            panelasesorinterno.Visible = true;
            Pannelalumno.Visible = false;
            panelasesorinterno.BringToFront();
            panelproyecto.Dock = DockStyle.None;
            Pannelalumno.Dock = DockStyle.None;
            panelasesorinterno.Dock = DockStyle.Fill;






        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (mostrandoalumno) {
                buscarproyecto();
            }

           
        }



        public void buscarproyecto() {
            int noproy;
            if (int.TryParse(Noproyectob.Text, out noproy))
            {
                proyectos = sug.Busquedadeproyectos(noproy);
                proyecto();
            }
            else
            {
                int nocontrol;
                if (int.TryParse(Nombreproyecto.Text, out nocontrol))
                {

                    alumnos = sug.Busquedaalumno(nocontrol, null);

                }
              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ag.IsDisposed){
                ag = new AgendarExpo();
            }
            ag.Show();
        }
    }
}
