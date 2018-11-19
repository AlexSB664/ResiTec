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
namespace AplicacionAlumnos
{
    public partial class Editardatos : Form
    {
        
        public static EdicionDatosalumno edicion = new EdicionDatosalumno();

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
            MessageBox.Show(AsesoresInternos.SelectedIndex.ToString());
            /*
            edicion.alumno.Proyecto_Residencia.IdAsesorInterno = AsesoresInternos.SelectedIndex;
            edicion.Guardarcambios();
    */    
    }
    }
}
