using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            var bindingList = new BindingList<Tablaproyecto>(proyectos);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Selecciontabla.SelectedItem.ToString() == "Proyectos") {
                proyecto();
            }
            if (Selecciontabla.SelectedItem.ToString() == "Alumnos")
            {
                alumno();
            }

        }
    }
}
