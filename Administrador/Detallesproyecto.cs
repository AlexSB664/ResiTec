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
        public static Eliminar eliminar = new Eliminar();
        public static Proyecto_Residencia ProyectoResidencia=new Proyecto_Residencia();
        public static List<statusdeproyecto> statusdeproye = new List<statusdeproyecto>();
        public BindingSource bindingsourcestatus = new BindingSource();
        public static int idstatus;
        public eliminardatoalumno AddItemCallback;

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
            Nproyecto.Text ="No de Proyecto : "+ ProyectoResidencia.No_Proyecto.ToString();
            string nombreperiodo;
            if (ProyectoResidencia.Periodos!=null) {
                if (ProyectoResidencia.Periodos.periodo == false)
                {
                    nombreperiodo = "Ene-Jun";
                }
                else
                {
                     nombreperiodo = "Julio-Dic";
                }
                Periodo.Text =nombreperiodo+ ProyectoResidencia.Periodos.año.ToString();
            }
            //establece datos del proyecto en los campos
       
                Nombreproyecto.Text = ProyectoResidencia.Nombre_Proyecto;
                Nombreempresa.Text =ProyectoResidencia.Nombre_de_la_Empresa;
                NombreAsesorexterno.Text = ProyectoResidencia.Nombre_Asesor_Externo;
                cargoasesor.Text = ProyectoResidencia.Cargo_Asesor_Externo;
                correoasesorext.Text = ProyectoResidencia.Correo_Asesor_Externo;
                telefonoasesorext.Text = ProyectoResidencia.Telefono_Asesor_Externo;

            
                if (ProyectoResidencia.Asesor_Interno != null)
                {
                    //Establece datos del asesor en los campos
                    Nombreasesorinterno.Text = ProyectoResidencia.Asesor_Interno.Nombre;
                    telefonoasesorinterno.Text = ProyectoResidencia.Asesor_Interno.Telefono;
                    correoasesorinterno.Text = ProyectoResidencia.Asesor_Interno.Correo;
                }
            


            statusdeproye = b.statusdeproyectos();
            bindingsourcestatus.DataSource = statusdeproye;
            Status.DataSource = bindingsourcestatus.DataSource;
            Status.DisplayMember = "nombre";
            Status.ValueMember = "IdStatus";
            //Status.SelectedItem = null;
            try
            {
                Status.SelectedValue = ProyectoResidencia.Status.IdStatus;
            }
            catch {
                Status.SelectedItem = null;
            }


            comentario.Text = ProyectoResidencia.Comentario;
            Dictamen.Checked =ProyectoResidencia.Dictamen;
            Anteproyecto.Checked = ProyectoResidencia.Status_Anteproyecto;
            reporte1.Checked = ProyectoResidencia.Primera_Evaluacion;
            reporte2.Checked = ProyectoResidencia.Segunda_Evaluacion;
            reporte3.Checked = ProyectoResidencia.Tercera_Evaluacion;
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
            catch(Exception ex) {
               // MessageBox.Show(ex.Message);
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Cambiar_status ca = new Cambiar_status();

            ca.actualizarstatus(idstatus,noproyecto,Dictamen.Checked,Anteproyecto.Checked,reporte1.Checked,reporte2.Checked,reporte3.Checked,comentario.Text);
            MessageBox.Show("Cambios guardados");
            AddItemCallback();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string Errores = null;
            var confirmResult = MessageBox.Show("Seguro que desea eliminar", "Confirme borrado",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                var confirmResult2 = MessageBox.Show("Desea eliminar los alumnos relacionados a este proyecto", "Confirme borrado",
                                   MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool si = eliminar.Eliminarresidenciaconalumnos(noproyecto, out Errores);

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
                else {
                    bool si = eliminar.Eliminarresidencia(noproyecto, out Errores);

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
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
