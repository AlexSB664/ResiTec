using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatizacionResidencias;
namespace Administrador
{
    public partial class Nuevohorario : Form
    {
        public addhorario addhorario;
        public int grupo;
        public int no;
        public Nuevohorario(int Noproyecto,int idgrupo)
        {
            InitializeComponent();
            no = Noproyecto;
            grupo = idgrupo;
        }

        private void Nuevohorario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            addhorario(new TablaHorario {No_proyecto=no,Fecha=monthCalendar1.SelectionStart,HoraFin=TimeSpan.Parse(Horafin.SelectedItem.ToString()+":"+ Minutofin.SelectedItem.ToString()),Horainicio= TimeSpan.Parse(Horainicio.SelectedItem.ToString() + @":" + minutoinicio.SelectedItem.ToString()) ,IdGrupo=grupo});
            this.Close();
        }
    }
}
