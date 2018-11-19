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
           

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AplicacionAlumnos.Template.verStatus v = new Template.verStatus();
            v.Show();
        }
    }
}
