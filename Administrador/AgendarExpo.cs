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
        public static Sugerencias sugerencias = new Sugerencias();
        public static List<HorarioPresentacion> horariossave = new List<HorarioPresentacion>();
        public static List<Tablaproyecto> proyectos = new List<Tablaproyecto>();
        public static List<TablaHorario> proyectosasignados = new List<TablaHorario>();
        public static Nuevogrupo gruposn = new Nuevogrupo(); 
        public static List<TablaAlumno> alumnos = new List<TablaAlumno>();
        public static List<TablaAsesor> asesores = new List<TablaAsesor>();
        public static List<ComboGrupo> gruposs = new List<ComboGrupo>();
        public BindingSource bindgrupos = new BindingSource();
        public static BindingList<ComboGrupo> bindinglistcombo = new BindingList<ComboGrupo>();
        public int currentproyecto;
        public static Nuevohorario nu = null;
        public ComboGrupo currentgroup = new ComboGrupo();
        public static string prueba;
        public AgendarExpo()
        {
            InitializeComponent();
        }

        private void AgendarExpo_Load(object sender, EventArgs e)
        {
            proyectos = sug.proyectosregistradossinasignar();
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
            Residenciasparaasignar.DataSource = null;
            Residenciasparaasignar.Rows.Clear();
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
            var bindingList = new BindingList<TablaHorario>(proyectosasignados);

            //var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            Residenciasasignadas.DataSource = null;
            Residenciasasignadas.Rows.Clear();

            Residenciasasignadas.DataSource = source;

            Residenciasasignadas.Columns["IdPresentacion"].Visible = false;


            // dataGridView1.Columns.Add(ColumnMonth);


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
            if (nu==null) {
                nu = new Nuevohorario(currentproyecto, currentgroup.IdGrupo);

            }

            if (nu.IsDisposed)
                {
                    nu = new Nuevohorario(currentproyecto, currentgroup.IdGrupo);
                }
                nu.addhorario = new addhorario(this.agregaragrupo);
                nu.Show();
           
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
                proyectosasignados = sug.horariosengrupos(currentgroup.IdGrupo);
                proyectos = sug.proyectosregistradossinasignar();

                proyectoasignados();
                proyecto();

            } catch(Exception ex) {
            }
        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Residenciasasignadas_DoubleClick(object sender, EventArgs e)
        {
            var pa = proyectosasignados.FirstOrDefault(x => x.No_proyecto == int.Parse(Residenciasasignadas.SelectedRows[0].Cells[0].Value.ToString()));
            proyectosasignados.Remove(pa);

            proyectos.Add(sug.Proyectoespecifico(pa.No_proyecto));
            proyectoasignados();
            proyecto();

        }


        public void agregaragrupo(TablaHorario item) {
            proyectosasignados.Add(item);

           var p= proyectos.FirstOrDefault(x=>x.No_Proyecto==item.No_proyecto);
            proyectos.Remove(p);
            proyectoasignados();
            proyecto();
        }

        private void Residenciasparaasignar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentproyecto = int.Parse(Residenciasparaasignar.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void Residenciasparaasignar_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentproyecto = int.Parse(Residenciasparaasignar.SelectedRows[0].Cells[0].Value.ToString());

        }

        private void Residenciasparaasignar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Residenciasparaasignar.ClearSelection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            horariossave = new List<HorarioPresentacion>();
            foreach (var hor in proyectosasignados) {

                horariossave.Add(new HorarioPresentacion {No_Proyecto=hor.No_proyecto,Fecha=hor.Fecha,Id_Grupo=hor.IdGrupo,HoraFin=hor.HoraFin,Horainicio=hor.Horainicio});
            }


            if (sugerencias.salvarhorario(horariossave,currentgroup.IdGrupo))
            {
                MessageBox.Show("Horarios guardados");
            }
            else {
                MessageBox.Show("No se pudieron  guardar los cambios");

            }

        }
    }
    public delegate void AddItemDelegate(ComboGrupo item);
    public delegate void addhorario(TablaHorario item);



}
