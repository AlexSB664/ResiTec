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
        public static Conexion con= new Conexion();
        public static Datosalumno regalumno=new Datosalumno();
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

            Alumno alumno = new Alumno() {
                NoControl = int.Parse(matricula),
                Nombre = nombre,
                Apellido_Paterno = apellidoPa,
                Apellido_Materno = apellidoMa,
                Semestre = int.Parse(semestre),
                Telefono = telefono,
                Correo = correo,
                NoProyecto = null,
                Proyecto_Residencia = null,
                Usuario = null
            };
           
                regalumno.Registrardatos(JsonConvert.SerializeObject(alumno), out Errores);
            
            if (Errores != null) {
                MessageBox.Show(Errores);
            }
            

        }

        
    }
}
