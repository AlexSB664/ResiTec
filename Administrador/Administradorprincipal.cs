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
using System.Linq.Dynamic;
using AutomatizacionResidencias.Acciones;
using System.Data.Entity.SqlServer;

namespace Administrador
{
    public partial class Administradorprincipal : Form
    {
        AgendarExpo ag = new AgendarExpo();

        Reenviarnip re = new Reenviarnip();
        Formatos formatos = new Formatos();
        Periodos perio = new Periodos();
        Exportardatos exportar = new Exportardatos();
        public static Busquedaentablas sug = new Busquedaentablas();
        public static List<Tablaproyecto> proyectos = new List<Tablaproyecto>();
        public static List<TablaAlumno> alumnos = new List<TablaAlumno>();
        public static List<TablaAsesor> asesores = new List<TablaAsesor>();
        public List<Tablaperiodo> periodos = new List<Tablaperiodo>();
        private bool sortAscending = false;
        public static bool mostrandoalumno = false;
        public static bool mostrandopryectos = false;
        public static bool mostrandoasesores = false;
        public AutomatizacionResidencias.Periodos currentperiodo = new AutomatizacionResidencias.Periodos();
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
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cargarperiodos();
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

        public void proyecto() {
            // var status = sug.statusdeproyectos();
        
            try
            {
                if (Periodos.Text != "")
                {
                    proyectos = proyectos.Where(x=>x.Periodo_año!=null).ToList();
                    proyectos = proyectos.Where(x => x.Periodo_año.Contains(Periodos.Text)).ToList();
                }
            }
            catch { }
            
            var bindingList = new BindingList<Tablaproyecto>(proyectos);

            //var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;



            //ColumnMonth.DataSource = bindingSourceMonth;
            ;
            //dataGridView1.Columns["Status"].Visible=false;
            dataGridView1.Columns["color"].Visible = false;
            dataGridView1.Columns["Asesorinterno"].Visible = false;

            // dataGridView1.Columns.Add(ColumnMonth);
            for (int i = 0; i < bindingList.Count; i++) {
                if (bindingList[i].color != null) {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromName(bindingList[i].color);
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }

            /*
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (row.Cells[11].Value!=null)
                {
                row.DefaultCellStyle.BackColor = Color.FromName(row.Cells[11].Value.ToString()); ;
                    foreach (DataGridViewCell cell in row.Cells) {
                        dataGridView1.Rows[row.Index].Cells[cell.ColumnIndex].Style.ForeColor = Color.White ;
                    }
                }
                */
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
            panelproyecto.Dock = DockStyle.Fill;
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


            if (mostrandoalumno == true) {

                Editardatos detallesalumno = new Editardatos(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                detallesalumno.AddItemCallback = new eliminardatoalumno(this.seeleiminoalumno);
                detallesalumno.Show();
            }
            if (mostrandopryectos == true) {
                Detallesproyecto de = new Detallesproyecto(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                de.AddItemCallback = new eliminardatoalumno(this.seeleiminoproyecto);
                de.Show();
            }
            if (mostrandoasesores) {
                DetallesAsesorinterno dea = new DetallesAsesorinterno((int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                dea.AddItemCallback = new eliminardatoalumno(this.seeliminoasesor);
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
            
            if (mostrandopryectos) {
                proyectos = sug.proyectosregistrados();

                proyecto();
                buscarproyecto();
            }
            if (mostrandoalumno) {
                alumnos = sug.Alumnos();
                alumno();
                buscaralumno();
            }
            if (mostrandoasesores) {
                asesores = sug.Asesores();
                asesor();
                buscarasesor();
                
            }


        }



        public void buscarproyecto() {
            int noproy;
            if (int.TryParse(Noproyectob.Text, out noproy))
            {
                proyectos = proyectos.Where(x => x.No_Proyecto == noproy).ToList();
            }
            else
            {

                if (Nombreproyecto.Text != "")
                {
                    proyectos = proyectos.Where(x => (x.Nombre_Proyecto ?? string.Empty).Contains(Nombreproyecto.Text)).ToList();
                }
                if (Empresa.Text != "") {
                    proyectos = proyectos.Where(x => (x.Nombre_de_la_Empresa ?? string.Empty).Contains(Empresa.Text)).ToList();

                }
                if (Area.Text != "")
                {
                    proyectos = proyectos.Where(x => (x.Area ?? string.Empty).Contains(Area.Text)).ToList();

                }
                if (Status.Text!="") {


                    proyectos = proyectos.Where(x=>(x.statusn ?? string.Empty).Contains(Status.Text)).ToList();

                }

            }

            proyecto();

        }


        public void buscaralumno()
        {
            int noproy;
            int sem;
            if (int.TryParse(Nocontrolb.Text, out noproy))
            {
                alumnos = alumnos.Where(x => x.NoControl == noproy).ToList();
            }
            else
            {

                if (nombrealumnob.Text != "")
                {
                    alumnos = alumnos.Where(x => (x.Nombre ?? string.Empty).Contains(nombrealumnob.Text)).ToList();
                }
                if (Apellidopalumnob.Text != "")
                {
                    alumnos = alumnos.Where(x => (x.Apellido_Paterno ?? string.Empty).Contains(Apellidopalumnob.Text)).ToList();

                }
                if (apellidomalumno.Text != "")
                {
                    alumnos = alumnos.Where(x => (x.Apellido_Materno ?? string.Empty).Contains(apellidomalumno.Text)).ToList();

                }
                if (int.TryParse(semestre.Text,out sem)) {
                    alumnos = alumnos.Where(x=>x.Semestre==sem).ToList();
                }

                if (int.TryParse(Noproyectoalumno.Text, out noproy))
                {
                    alumnos = alumnos.Where(x => x.NoProyecto == noproy).ToList();
                }

                if (genero.Text!="")
                {
                    alumnos = alumnos.Where(x => (x.Genero ?? string.Empty).Contains(genero.Text)).ToList();
                }

            }

            alumno();

        }

        public void buscarasesor()
        {
            int noproy;
            int sem;
            if (int.TryParse(AsesorId.Text, out noproy))
            {
                asesores = asesores.Where(x => x.IdAsesor == noproy).ToList();
            }
            else
            {

                if (Nombreasesorinterno.Text != "")
                {
                    asesores = asesores.Where(x => (x.Nombre ?? string.Empty).Contains(Nombreasesorinterno.Text)).ToList();
                }
                

            }

            asesor();

        }

        public void seeleiminoalumno()
        {
            alumnos = sug.Alumnos();
            alumno();
        }


        public void seeleiminoproyecto()
        {
            proyectos = sug.proyectosregistrados();
            proyecto();
        }

        public void seeliminoasesor()
        {
            asesores = sug.Asesores();
            asesor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ag.IsDisposed) {
                ag = new AgendarExpo();
            }
            ag.Show();
        }

        private void Periodo_Click(object sender, EventArgs e)
        {
            if (perio.IsDisposed) {
                perio = new Periodos();
            }
            perio.addperiodo = new addperiodo(this.cargarperiodos);
            perio.Show();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (mostrandopryectos) {
                sortproyectos(sender, e);
            }
            if (mostrandoalumno) {
                sortalumnos(sender, e);
            }
            if (mostrandoasesores) {
                sortasesores(sender, e);
            }
            // dataGridView1.Columns.Add(ColumnMonth);



        }




        public void sortproyectos(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Tablaproyecto> temp;
            if (sortAscending)
            {
                //proyectos = proyectos.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).ToList();

                temp = proyectos.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).ToList();
                dataGridView1.DataSource = temp;
                sortAscending = !sortAscending;

            }
            else
            {
                temp = proyectos.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
                dataGridView1.DataSource = temp;
                sortAscending = !sortAscending;
            }

            //dataGridView1.Columns["color"].Visible = false;
            //dataGridView1.Columns["Asesorinterno"].Visible = false;

            for (int i = 0; i < temp.Count; i++)
            {

                if (temp[i].color != null)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromName(temp[i].color);
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }
        }


        public void sortalumnos(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<TablaAlumno> temp;
            if (sortAscending)
            {
                //proyectos = proyectos.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).ToList();

                temp = alumnos.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).ToList();
                dataGridView1.DataSource = temp;
                sortAscending = !sortAscending;

            }
            else
            {
                temp = alumnos.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
                dataGridView1.DataSource = temp;
                sortAscending = !sortAscending;
            }

            //dataGridView1.Columns["color"].Visible = false;
            //dataGridView1.Columns["Asesorinterno"].Visible = false;

        }


        public void sortasesores(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<TablaAsesor> temp;
            if (sortAscending)
            {
                //proyectos = proyectos.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).ToList();

                temp = asesores.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).ToList();
                dataGridView1.DataSource = temp;
                sortAscending = !sortAscending;

            }
            else
            {
                temp = asesores.OrderBy(dataGridView1.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
                dataGridView1.DataSource = temp;
                sortAscending = !sortAscending;
            }

            //dataGridView1.Columns["color"].Visible = false;
            //dataGridView1.Columns["Asesorinterno"].Visible = false;

        }

        public void cargarperiodos (){
            currentperiodo = sug.periodoactual();
            periodos = sug.periodos();
            Periodos.DataSource = periodos;
            Periodos.DisplayMember = "periodo";
            Periodos.ValueMember = "idperiodo";
            Periodos.SelectedValue = currentperiodo.Idperiodo;
            
            }

        private void button4_Click(object sender, EventArgs e)
        {
            if (exportar.IsDisposed) {
                exportar = new Exportardatos();
            }
            exportar.Show();
        }
    }
    public delegate void eliminardatoalumno();
    public delegate void addperiodo();
}
