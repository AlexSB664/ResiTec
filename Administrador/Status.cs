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
using AutomatizacionResidencias.Acciones;
using AutomatizacionResidencias.Decorator;
using Newtonsoft.Json;
namespace Administrador
{
    public partial class Status : Form
    {
        public string nombre;
        public string descripcion;
        public string color;
        public static Eliminar eliminar = new Eliminar();
        public static Sugerencias op = new Sugerencias();
        public static string cursta;
        public static BindingSource bin = new BindingSource();
        public static List<AutomatizacionResidencias.Status> status = new List<AutomatizacionResidencias.Status>(); 
        public Status()
        {
            InitializeComponent();
        }

        public void datagrid()
        {
            foreach (var n in status) {
                n.Proyecto_Residencia=null;
            }
            var bindingList = new BindingList<AutomatizacionResidencias.Status>(status);

            

            var source = new BindingSource(bindingList, null);

            dataGridView1.DataSource = source;
            dataGridView1.Columns["Proyecto_Residencia"].Visible = false;



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

            string Errore;
            status = op.status();
            datagrid();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cursta = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string errore;
            if (eliminar.Eliminarstatus(int.Parse(cursta), out errore))
            {
                status = op.status();
                datagrid();
            }
            else {
                MessageBox.Show(errore);
            }

        }
    }
}
