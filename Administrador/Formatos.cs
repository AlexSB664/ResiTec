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

            cr.crearwordsolicitudresidencia();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            alumno = new EdicionDatosalumno();
            alumno.buscaralumno(textBox1.Text);
            cr.establecer(alumno.alumno);

            cr.crearwordasignarrevisor();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            alumno = new EdicionDatosalumno();
            alumno.buscaralumno(textBox1.Text);
            cr.establecer(alumno.alumno);

            cr.abrir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            alumno = new EdicionDatosalumno();
            alumno.buscaralumno(textBox1.Text);
            cr.establecer(alumno.alumno);

            cr.crearwordasignacionasesorinterno();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            alumno = new EdicionDatosalumno();
            alumno.buscaralumno(textBox1.Text);
            cr.establecer(alumno.alumno);

            cr.crearwordconstanciarevisores();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            alumno = new EdicionDatosalumno();
            alumno.buscaralumno(textBox1.Text);
            cr.establecer(alumno.alumno);

            cr.crearwordRegistroproyecto();

        }
    
    }
}
