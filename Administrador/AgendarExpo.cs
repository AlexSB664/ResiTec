using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatizacionResidencias;
using AutomatizacionResidencias.Acciones;
using Newtonsoft.Json;
namespace Administrador
{
    public partial class AgendarExpo : Form
    {
        public static Busquedaentablas sug = new Busquedaentablas();
        public static List<Tablaproyecto> proyectos = new List<Tablaproyecto>();
        public static List<Tablaproyecto> proyectosasignados = new List<Tablaproyecto>();
        public static Nuevogrupo gruposn = new Nuevogrupo(); 
        public static List<TablaAlumno> alumnos = new List<TablaAlumno>();
        public static List<TablaAsesor> asesores = new List<TablaAsesor>();
        public static List<ComboGrupo> gruposs = new List<ComboGrupo>();
        public BindingSource bindgrupos = new BindingSource();
        public static BindingList<ComboGrupo> bindinglistcombo = new BindingList<ComboGrupo>();

        public ComboGrupo currentgroup = new ComboGrupo();
        public static string prueba;
        public AgendarExpo()
        {
            InitializeComponent();
        }

        private void AgendarExpo_Load(object sender, EventArgs e)
        {
            proyectos = sug.proyectosregistrados();
            gruposs = sug.todosgrupos();
            proyecto();
            grupos();
        }


        public void proyecto()
        {
            // var status = sug.statusdeproyectos();
            var bindingList = new BindingList<Tablaproyecto>(proyectos);

            //var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            Residenciasparaasignar.DataSource = source;


            DataGridViewComboBoxColumn ColumnMonth = new DataGridViewComboBoxColumn();
            ColumnMonth.DataPropertyName = "status";
            ColumnMonth.HeaderText = "status";
            ColumnMonth.Width = 120;
            //ColumnMonth.DataSource = bindingSourceMonth;
            ColumnMonth.ValueMember = "IdStatus";
            ColumnMonth.DisplayMember = "nombre";
            Residenciasparaasignar.Columns["Status"].Visible = false;
            // dataGridView1.Columns.Add(ColumnMonth);
            foreach (DataGridViewRow row in Residenciasparaasignar.Rows)
                if (row.Cells[11].Value != null)
                {
                    row.DefaultCellStyle.BackColor = Color.FromName(row.Cells[11].Value.ToString()); ;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        Residenciasparaasignar.Rows[row.Index].Cells[cell.ColumnIndex].Style.ForeColor = Color.White;
                    }
                }

        }


        public void proyectoasignados()
        {
            // var status = sug.statusdeproyectos();
            var bindingList = new BindingList<Tablaproyecto>(proyectosasignados);

            //var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            Residenciasasignadas.DataSource = source;


            DataGridViewComboBoxColumn ColumnMonth = new DataGridViewComboBoxColumn();
            ColumnMonth.DataPropertyName = "status";
            ColumnMonth.HeaderText = "status";
            ColumnMonth.Width = 120;
            //ColumnMonth.DataSource = bindingSourceMonth;
            ColumnMonth.ValueMember = "IdStatus";
            ColumnMonth.DisplayMember = "nombre";
            Residenciasasignadas.Columns["Status"].Visible = false;
            // dataGridView1.Columns.Add(ColumnMonth);
            foreach (DataGridViewRow row in Residenciasasignadas.Rows)
                if (row.Cells[11].Value != null)
                {
                    row.DefaultCellStyle.BackColor = Color.FromName(row.Cells[11].Value.ToString()); ;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        Residenciasasignadas.Rows[row.Index].Cells[cell.ColumnIndex].Style.ForeColor = Color.White;
                    }
                }

        }

        public void grupos() {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            bindgrupos.DataSource = gruposs;
            comboBox1.DataSource = bindgrupos.DataSource;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdGrupo";
            comboBox1.SelectedItem = null;

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Residenciasasignadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Asignar_Click(object sender, EventArgs e)
        {
            proyectosasignados.Add(proyectos.FirstOrDefault(x=>x.No_Proyecto== int.Parse( Residenciasparaasignar.SelectedRows[0].Cells[0].Value.ToString())));

            proyectoasignados();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        private void SetCheckBox(ComboGrupo item)
        {
            gruposs.Add(item);
            grupos();
        }

        private void agregarhorario(ComboGrupo item)
        {
            gruposs.Add(item);
            grupos();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (gruposn.IsDisposed) {
                gruposn = new Nuevogrupo();
            }
            gruposn.AddItemCallback = new AddItemDelegate(this.SetCheckBox);
            gruposn.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                var id = int.Parse(comboBox1.SelectedValue.ToString());
                currentgroup = gruposs.FirstOrDefault(x=>x.IdGrupo== id);
                grupo.Text = currentgroup.Nombre;
            } catch { }
        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Residenciasasignadas_DoubleClick(object sender, EventArgs e)
        {
            
            proyectosasignados.Remove(proyectos.FirstOrDefault(x => x.No_Proyecto == int.Parse(Residenciasparaasignar.SelectedRows[0].Cells[0].Value.ToString())));

            proyectoasignados();

        }
    }
    public delegate void AddItemDelegate(ComboGrupo item);
    public delegate void addhorario(HorarioPresentacion item);


}
