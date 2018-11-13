using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrador.Template
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void proyecto_ResidenciaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.proyecto_ResidenciaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.proyectosdeResidencia);

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectosdeResidencia.Proyecto_Residencia' Puede moverla o quitarla según sea necesario.
            this.proyecto_ResidenciaTableAdapter.Fill(this.proyectosdeResidencia.Proyecto_Residencia);

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
