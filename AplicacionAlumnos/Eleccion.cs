using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
