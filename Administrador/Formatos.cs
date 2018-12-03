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
            if (validar()) {
                try
                {
                    alumno = new EdicionDatosalumno();
                    alumno.buscaralumno(textBox1.Text);
                    cr.establecer(alumno.alumno);

                    cr.crearwordsolicitudresidencia();
                }
                catch { }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    alumno = new EdicionDatosalumno();
                    alumno.buscaralumno(textBox1.Text);
                    cr.establecer(alumno.alumno);

                    cr.crearwordasignarrevisor();
                }
                catch { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    alumno = new EdicionDatosalumno();
                    alumno.buscaralumno(textBox1.Text);
                    cr.establecer(alumno.alumno);

                    cr.abrir();
                }
                catch { }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    alumno = new EdicionDatosalumno();
                    alumno.buscaralumno(textBox1.Text);
                    cr.establecer(alumno.alumno);

                    cr.crearwordasignacionasesorinterno();
                }
                catch { }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    alumno = new EdicionDatosalumno();
                    alumno.buscaralumno(textBox1.Text);
                    cr.establecer(alumno.alumno);

                    cr.crearwordconstanciarevisores();
                }
                catch { }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    alumno = new EdicionDatosalumno();
                    alumno.buscaralumno(textBox1.Text);
                    cr.establecer(alumno.alumno);

                    cr.crearwordRegistroproyecto();
                }
                catch { }
            }

        }


        public bool validar() {
            int t;
            if (int.TryParse(textBox1.Text, out t))
            {
                return true;
            }
            else {
                MessageBox.Show("No es un numero de control valido");
                return false;
            }
        }
    }
}
