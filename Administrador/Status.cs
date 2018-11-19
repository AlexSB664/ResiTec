using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizacionResidencias.Decorator;
using Newtonsoft.Json;
namespace Administrador
{
    public partial class Status : Form
    {
        public string nombre;
        public string descripcion;
        public string color;
        public Status()
        {
            InitializeComponent();
        }

        private void cmbboxClr_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.FillRectangle(b, rect.X , rect.Y , rect.Width, rect.Height);
            }
        }

        private void Status_Load(object sender, EventArgs e)
        {
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.cmbboxClr.Items.Add(c.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Errores;
            nombre = Nombre.Text;
            descripcion = Descripcion.Text;
            color = cmbboxClr.SelectedItem.ToString();

           AutomatizacionResidencias.Decorator.Status  regst = new AutomatizacionResidencias.Decorator.Status();
            regst.Registrardatos(JsonConvert.SerializeObject(new AutomatizacionResidencias.Status {Nombre=this.nombre,Descripcion=this.descripcion,Color=this.color}),out Errores);
            MessageBox.Show(Errores);
        }
    }
}
