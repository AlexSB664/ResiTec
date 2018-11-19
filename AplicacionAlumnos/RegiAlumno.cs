using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizacionResidencias.Acciones;
using AutomatizacionResidencias.Decorator;
using AutomatizacionResidencias.Modelos;
using Newtonsoft.Json;
using AutomatizacionResidencias;
namespace AplicacionAlumnos
{
    public partial class RegiAlumno : Form
    {
        public static string matricula;
        public static string nombre;
        public static string apellidoPa;
        public static string apellidoMa;
        public static string semestre;
        public static string telefono;
        public static string correo;
        public string Errores;
        public Proyecto_Residencia proyectoresidencia= null;
        public Asesor_Interno asesorinterno= null;
        public static Conexion con= new Conexion();
        public static Datosalumno regalumno=new Datosalumno();
        public static Proyectoresidencia regresidencia = new Proyectoresidencia();
        public static AsesorInterno regasesorinterno = new AsesorInterno();
        public static BindingSource bindingsourceproyectos = new BindingSource();
        public static BindingSource bindingsourceasesores = new BindingSource();
        public List<Proyecto_Residencia> proyectos = new List<Proyecto_Residencia>();
        public List<Asesor_Interno> asesores = new List<Asesor_Interno>();
        public static Sugerencias sugerencia= new Sugerencias();
        public static bool residenciaexistente = false;
        public static bool asesorinternoexistente = false;
        public static int Nopro;
        public RegiAlumno()
        {
            InitializeComponent();
        }

        private void guardardatosalumno(object sender, EventArgs e)
        {
            RegiAlumno.matricula = NoControl.Text;
            RegiAlumno.nombre = nombrealumno.Text;
            RegiAlumno.apellidoPa = Apellidopalumno.Text;
            RegiAlumno.apellidoMa = Apellidomalumno.Text;
            RegiAlumno.semestre = numsemestre.Text;
            RegiAlumno.telefono = numtelefonoalumno.Text;
            RegiAlumno.correo = correoelectronicoalumno.Text;


            Alumno alumno = new Alumno()
            {
                NoControl = int.Parse(matricula),
                Nombre = nombre,
                Apellido_Paterno = apellidoPa,
                Apellido_Materno = apellidoMa,
                Semestre = int.Parse(semestre),
                Telefono = telefono,
                Correo = correo,
                Usuario = new AutomatizacionResidencias.Usuario() { Usuario1 = correo, Rol = "alumno" }
                
            };


        

            if (residenciaexistente == false)
            {
                proyectoresidencia = new Proyecto_Residencia();
                proyectoresidencia.Nombre_Proyecto = Nombreproyecto.Text;
                proyectoresidencia.Nombre_de_la_Empresa = Nombreempresa.Text;
                proyectoresidencia.Nombre_Asesor_Externo = NombreAsesorexterno.Text;
                proyectoresidencia.Cargo_Asesor_Externo = cargoasesor.Text;
                proyectoresidencia.Telefono_Asesor_Externo = telefonoasesorext.Text;
                proyectoresidencia.Correo_Asesor_Externo = correoasesorext.Text;
                proyectoresidencia.Asesor_Interno = asesorinterno;
                proyectoresidencia.Fecha_Registro = DateTime.Now;

                alumno.Proyecto_Residencia = proyectoresidencia;

                if (asesorinternoexistente == false)
                {
                    asesorinterno = new Asesor_Interno();
                    asesorinterno.Nombre = NombreAsesorinterno.Text ;
                    asesorinterno.Telefono = Telefonoasesorinterno.Text;
                    asesorinterno.Correo = Correoasesorinterno.Text;
                    proyectoresidencia.Asesor_Interno = asesorinterno;
                    regalumno.Registrardatos(JsonConvert.SerializeObject(alumno), out Errores);


                }
                else {
                    alumno.Proyecto_Residencia.IdAsesorInterno=asesorinterno.IdAsesor;

                }
            }
            else {
                alumno.NoProyecto = proyectoresidencia.No_Proyecto;
                regalumno.Registrardatosresidenciaelegida(JsonConvert.SerializeObject(alumno), out Errores);


            }






            if (Errores != null) {
                MessageBox.Show(Errores);
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var proyecto = proyectos.FirstOrDefault(x => x.No_Proyecto == int.Parse(Residencias.SelectedValue.ToString()));
                var asesor = asesores.FirstOrDefault(x=>x.IdAsesor==proyecto.IdAsesorInterno);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegiAlumno_Load(object sender, EventArgs e)
        {
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
        }
    }
}
