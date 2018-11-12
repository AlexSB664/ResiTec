using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizacionResidencias.Acciones;
namespace AplicacionAlumnos
{
    public partial class Eleccion : Form
    {
        public Eleccion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegiAlumno reg = new RegiAlumno();
            reg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Errores = null;
            bool alumno=false;
            string alumnocorreo=Correoalumno.Text;
            string password=Pinalumno.Text;
            Autentificacion a = new Autentificacion();
            alumno=a.autentificaralumno(alumnocorreo, password, out Errores);
            if (alumno==true) {
                Editardatos ed = new Editardatos(alumnocorreo);
                ed.Show();
            }
            else {
                MessageBox.Show("Credenciales incorrectas");
            }

        }
    }
}
