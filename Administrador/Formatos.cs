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
using AutomatizacionResidencias.Decorator;
namespace Administrador
{
    public partial class Formatos : Form
    {
        public Crearformatos cr = new Crearformatos();

        public static EdicionDatosalumno alumno;
        public Formatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alumno = new EdicionDatosalumno();
            alumno.buscaralumno(textBox1.Text);
           cr.establecer(alumno.alumno);

            cr.HTMLToPDF("formato1");

        }
    }
}
