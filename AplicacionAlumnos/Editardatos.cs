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
using AutomatizacionResidencias.Decorator;
using AutomatizacionResidencias.Acciones;
namespace AplicacionAlumnos
{
    public partial class Editardatos : Form
    {
        public static Proyectoresidencia regresidencia = new Proyectoresidencia();
        public static AsesorInterno regasesorinterno = new AsesorInterno();
        public Proyecto_Residencia proyectoresidencia = null;

        public static BindingSource bindingsourceproyectos = new BindingSource();
        public static BindingSource bindingsourceasesores = new BindingSource();
        public List<Proyecto_Residencia> proyectos = new List<Proyecto_Residencia>();
        public List<Asesor_Interno> asesores = new List<Asesor_Interno>();
        public static Sugerencias sugerencia = new Sugerencias();
        public static bool residenciaexistente = false;
        public static bool asesorinternoexistente = false;
        public static EdicionDatosalumno edicion = new EdicionDatosalumno();
        public static int Nopro;
        public static string Correo = null;
        public Editardatos(string correo)
        {
            InitializeComponent();
            Correo = correo;
        }

        private void Editardatos_Load(object sender, EventArgs e)
        {
            //Carga datos del alumno residencia
            edicion.buscaralumno(Correo);


            //Establece datos de alumno en los campos
            nombrealumno.Text = edicion.alumno.Nombre.ToString();
            Apellidopalumno.Text = edicion.alumno.Apellido_Paterno;
            Apellidomalumno.Text = edicion.alumno.Apellido_Materno;
            numsemestre.Text = edicion.alumno.Semestre.ToString();
            numtelefonoalumno.Text = edicion.alumno.Telefono;
            correoelectronicoalumno.Text = edicion.alumno.Correo;

            //establece datos del proyecto en los campos
            Nombreproyecto.Text = edicion.alumno.Proyecto_Residencia.Nombre_Proyecto;
            Nombreempresa.Text = edicion.alumno.Proyecto_Residencia.Nombre_de_la_Empresa;
            NombreAsesorexterno.Text = edicion.alumno.Proyecto_Residencia.Nombre_Asesor_Externo;
            cargoasesor.Text = edicion.alumno.Proyecto_Residencia.Cargo_Asesor_Externo;
            correoasesorext.Text = edicion.alumno.Proyecto_Residencia.Correo_Asesor_Externo;
            telefonoasesorext.Text = edicion.alumno.Proyecto_Residencia.Telefono_Asesor_Externo;



            //Establece datos del asesor en los campos
            NombreAsesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Nombre;
            Telefonoasesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Telefono;
            Correoasesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Correo;

            proyectos = sugerencia.proyectosregistrados();
            bindingsourceproyectos.DataSource = proyectos;
            Residencias.DataSource = bindingsourceproyectos.DataSource;
            Residencias.DisplayMember = "Nombre_Proyecto";
            Residencias.ValueMember = "No_Proyecto";

            asesores = sugerencia.Asesoresinternos();
            bindingsourceasesores.DataSource = asesores;
            AsesoresInternos.DataSource = bindingsourceasesores.DataSource;
            AsesoresInternos.DisplayMember = "Nombre";
            AsesoresInternos.ValueMember = "IdAsesor";
            Residencias.SelectedItem = null;
            AsesoresInternos.SelectedItem = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //se guarda cualquier cambio hecho

            edicion.alumno.Nombre = nombrealumno.Text;
            edicion.alumno.Apellido_Paterno = Apellidopalumno.Text;
            edicion.alumno.Correo = correoelectronicoalumno.Text;
            edicion.alumno.Semestre =int.Parse( numsemestre.Text);
            edicion.alumno.Telefono = numtelefonoalumno.Text;


            edicion.alumno.Proyecto_Residencia.Nombre_Proyecto = Nombreproyecto.Text;
           edicion.alumno.Proyecto_Residencia.Nombre_de_la_Empresa = Nombreempresa.Text;
            edicion.alumno.Proyecto_Residencia.Nombre_Asesor_Externo = NombreAsesorexterno.Text ;
            edicion.alumno.Proyecto_Residencia.Cargo_Asesor_Externo = cargoasesor.Text;
             edicion.alumno.Proyecto_Residencia.Correo_Asesor_Externo= correoasesorext.Text ;
          edicion.alumno.Proyecto_Residencia.Telefono_Asesor_Externo = telefonoasesorext.Text ;



          edicion.alumno.Proyecto_Residencia.Asesor_Interno.Nombre = NombreAsesorinterno.Text ;
           edicion.alumno.Proyecto_Residencia.Asesor_Interno.Telefono =Telefonoasesorinterno.Text ;
         edicion.alumno.Proyecto_Residencia.Asesor_Interno.Correo = Correoasesorinterno.Text;




            //se guardan los cambios a la bd
            edicion.Guardarcambios();
            MessageBox.Show("Se han guardado los cambios");
        }

        private void AsesoresInternos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var asesor = asesores.FirstOrDefault(x => x.IdAsesor == AsesoresInternos.SelectedIndex);

                NombreAsesorinterno.Text = asesor.Nombre;
                Telefonoasesorinterno.Text = asesor.Telefono;
                Correoasesorinterno.Text = asesor.Correo;
                residenciaexistente = true;
                asesorinternoexistente = true;
            }
            catch { }
            /*
            edicion.alumno.Proyecto_Residencia.IdAsesorInterno = AsesoresInternos.SelectedIndex;
            edicion.Guardarcambios();
    */
        }

        private void Residencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var proyecto = proyectos.FirstOrDefault(x => x.No_Proyecto == int.Parse(Residencias.SelectedValue.ToString()));
                var asesor = asesores.FirstOrDefault(x => x.IdAsesor == proyecto.IdAsesorInterno);
                Nombreproyecto.Text = proyecto.Nombre_Proyecto;
                Nombreempresa.Text = proyecto.Nombre_de_la_Empresa;
                NombreAsesorexterno.Text = proyecto.Nombre_Asesor_Externo;
                cargoasesor.Text = proyecto.Cargo_Asesor_Externo;
                correoasesorext.Text = proyecto.Correo_Asesor_Externo;
                telefonoasesorext.Text = proyecto.Telefono_Asesor_Externo;
                NombreAsesorinterno.Text = asesor.Nombre;
                proyectoresidencia = proyecto;
                Nopro = proyecto.No_Proyecto;
                residenciaexistente = true;
                asesorinternoexistente = true;
            }
            catch
            {

            }
        }
    }
}
