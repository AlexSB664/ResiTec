using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatizacionResidencias;
using AutomatizacionResidencias.Acciones;
namespace Administrador
{
    public partial class DetallesAsesorinterno : Form
    {
        public static List<Tablaproyecto> proyectos = new List<Tablaproyecto>();

        public Busquedaentablas sug = new Busquedaentablas();
        public Asesor_Interno asesor = new Asesor_Interno();
        public Eliminar eliminar=new Eliminar();
        public eliminardatoalumno AddItemCallback;

        public DetallesAsesorinterno(int Idasesorinterno)
        {
            InitializeComponent();
            asesor = sug.Buscarasesorinternoespecifico(Idasesorinterno);

        }

        private void DetallesAsesorinterno_Load(object sender, EventArgs e)
        {
            NombreAsesorinterno.Text = asesor.Nombre;
            Telefonoasesorinterno.Text = asesor.Telefono;
            Correoasesorinterno.Text = asesor.Correo;

            proyectos = sug.Proyectosporasesor(asesor.IdAsesor);
            proyecto();

        }

        public void proyecto()
        {
            // var status = sug.statusdeproyectos();
            var bindingList = new BindingList<Tablaproyecto>(proyectos);

            //var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;


          
            //ColumnMonth.DataSource = bindingSourceMonth;
          ;
            dataGridView1.Columns["Status"].Visible = false;
            // dataGridView1.Columns.Add(ColumnMonth);
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].color != null)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromName(bindingList[i].color);
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }


        }

        private void Eliminar_Click(object sender, EventArgs e)
        {

           
                string Errores = null;
                var confirmResult = MessageBox.Show("Seguro que desea eliminar", "Confirme borrado",
                                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool si = eliminar.Eliminarasesor(asesor.IdAsesor, out Errores);

                    if (si == true)
                    {

                        MessageBox.Show("Se elimino");
                        AddItemCallback();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Errores: " + Errores);

                    }
                }
                else
                {
                    // If 'No', do something here.
                }
            
        }
    }
}
