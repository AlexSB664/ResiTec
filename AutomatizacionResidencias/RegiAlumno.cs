using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatizacionResidencias
{
    public partial class RegiAlumno : Form
    {
        public static string matricula;
        public static string nombre;
        public static string apellidoPa;
        public static string apellidoMa;
        public static string semestre;
        public static string telefono;
        public static string correo;


        public RegiAlumno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegiAlumno.matricula = textBoxMatricula.Text;
            RegiAlumno.nombre = textBoxNombre.Text;
            RegiAlumno.apellidoPa = textBoxApePa.Text;
            RegiAlumno.apellidoMa = textBoxApeMa.Text;
            RegiAlumno.semestre = textBoxSemestre.Text;
            RegiAlumno.telefono = textBoxTelefono.Text;
            RegiAlumno.correo = textBoxCorreo.Text;
        }
    }
}
