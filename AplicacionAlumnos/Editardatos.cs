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
using AutomatizacionResidencias.Decorator;
namespace AplicacionAlumnos
{
    public partial class Editardatos : Form
    {
        public static EdicionDatosalumno edicion = new EdicionDatosalumno();

        public static string Correo = null;
        public Editardatos(string correo)
        {
            InitializeComponent();
            Correo = correo;
        }

        private void Editardatos_Load(object sender, EventArgs e)
        {
            edicion.buscaralumno(Correo);
            nombrealumno.Text = edicion.alumno.Nombre.ToString();
            Apellidopalumno.Text = edicion.alumno.Apellido_Paterno;
            Apellidomalumno.Text = edicion.alumno.Apellido_Materno;
            numsemestre.Text = edicion.alumno.Semestre.ToString();
            numtelefonoalumno.Text = edicion.alumno.Telefono;
            correoelectronicoalumno.Text = edicion.alumno.Correo;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edicion.alumno.Nombre = nombrealumno.Text;
            edicion.alumno.Apellido_Paterno = Apellidopalumno.Text;
            edicion.alumno.Correo = correoelectronicoalumno.Text;
            edicion.alumno.Semestre =int.Parse( numsemestre.Text);
            
            edicion.alumno.Telefono = numtelefonoalumno.Text;

            edicion.Guardarcambios();
            MessageBox.Show("Se han guardado los cambios");
        }
    }
}
