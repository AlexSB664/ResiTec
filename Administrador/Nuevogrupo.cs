using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatizacionResidencias;
using AutomatizacionResidencias.Modelos;
using AutomatizacionResidencias.Acciones;
namespace Administrador
{
    public partial class Nuevogrupo : Form
    {
        public Nuevogrupo()
        {
            InitializeComponent();
        }
        public AddItemDelegate AddItemCallback;


        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Nombre.Text!=null && Descripcion.Text!=null) {
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                    context.Grupos.Add(new Grupos { Nombre=Nombre.Text,Descripcion=Descripcion.Text});

                    context.SaveChanges();
                   var gr= context.Grupos.OrderByDescending(x=>x.IdGrupo).FirstOrDefault();
                    AddItemCallback(new ComboGrupo {IdGrupo= gr.IdGrupo,Nombre=gr.Nombre,Descripcion=gr.Descripcion});
                    this.Close();
                }
            }
        }

        private void Nuevogrupo_Load(object sender, EventArgs e)
        {

        }
    }
}
