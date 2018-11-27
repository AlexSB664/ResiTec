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
namespace Administrador
{
    public partial class Detallesproyecto : Form
    {
        public int noproyecto;
        public static List<TablaAlumno> alumnos = new List<TablaAlumno>();
        public static Busquedaentablas sug = new Busquedaentablas();

        public static Proyecto_Residencia ProyectoResidencia=new Proyecto_Residencia();
        public static List<statusdeproyecto> statusdeproye = new List<statusdeproyecto>();
        public BindingSource bindingsourcestatus = new BindingSource();
        public static int idstatus;
        public AutomatizacionResidencias.Acciones.Busquedaentablas b= new AutomatizacionResidencias.Acciones.Busquedaentablas(); 
        public Detallesproyecto(int no)
        {
            InitializeComponent();
            noproyecto = no;
        }

        private void Detallesproyecto_Load(object sender, EventArgs e)
        {
            //Carga datos del alumno residencia
          ProyectoResidencia=  b.proyectodetalles(noproyecto);



            //establece datos del proyecto en los campos
       
                Nombreproyecto.Text = ProyectoResidencia.Nombre_Proyecto;
                Nombreempresa.Text =ProyectoResidencia.Nombre_de_la_Empresa;
                NombreAsesorexterno.Text = ProyectoResidencia.Nombre_Asesor_Externo;
                cargoasesor.Text = ProyectoResidencia.Cargo_Asesor_Externo;
                correoasesorext.Text = ProyectoResidencia.Correo_Asesor_Externo;
                telefonoasesorext.Text = ProyectoResidencia.Telefono_Asesor_Externo;

            /*
                if (edicion.alumno.Proyecto_Residencia.Asesor_Interno != null)
                {
                    //Establece datos del asesor en los campos
                    NombreAsesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Nombre;
                    Telefonoasesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Telefono;
                    Correoasesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Correo;
                }
            */


            statusdeproye = b.statusdeproyectos();
            bindingsourcestatus.DataSource = statusdeproye;
            Status.DataSource = bindingsourcestatus.DataSource;
            Status.DisplayMember = "nombre";
            Status.ValueMember = "IdStatus";
            Status.SelectedItem = null;

            alumnos = sug.alumnosporproyecto(ProyectoResidencia.No_Proyecto);

            alumno();
        }

        public void alumno()
        {

            var bindingList = new BindingList<TablaAlumno>(alumnos);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idstatus = int.Parse(Status.SelectedValue.ToString());
            }
            catch { }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Cambiar_status ca = new Cambiar_status();
            ca.actualizarstatus(idstatus,noproyecto);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Seguro que desea eliminar","Confirme borrado",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                MessageBox.Show("Se elimino");
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
