using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using AutomatizacionResidencias.Acciones;
namespace AutomatizacionResidencias.Decorator
{
    public class Datosalumno : REGISTRO
    {
        public override void Registrardatos(string datos,out string Errores)
        {
            try
            {
                Errores = null;
                var al = JsonConvert.DeserializeObject<Alumno>(datos);

                alumno.NoControl = al.NoControl;
                alumno.Nombre = al.Nombre;
                alumno.Semestre = al.Semestre;
                alumno.Telefono = al.Telefono;
                alumno.Correo = al.Correo;
                alumno.Apellido_Paterno = al.Apellido_Paterno;
                alumno.Apellido_Materno = al.Apellido_Materno;
                alumno.Usuario = al.Usuario;
                alumno.Proyecto_Residencia = al.Proyecto_Residencia;
            }
            catch(Exception ex) {
                Errores = ex.InnerException.Message;
            }
            try
            {
                
                    alumno.RegisterObserver(out Errores);


                
            }
            catch(Exception ex)
                {
                Errores = ex.Message;

            }
        }




        public  void Registrardatosresidenciaelegida(Alumno datos, out string Errores)
        {
            try
            {
                Errores = null;
                var al = datos;

                alumno.NoControl = al.NoControl;
                alumno.Nombre = al.Nombre;
                alumno.Semestre = al.Semestre;
                alumno.Telefono = al.Telefono;
                alumno.Correo = al.Correo;
                alumno.Apellido_Paterno = al.Apellido_Paterno;
                alumno.Apellido_Materno = al.Apellido_Materno;
                alumno.Usuario = al.Usuario;
                alumno.NoProyecto = al.NoProyecto;
                alumno.Genero = al.Genero;
                alumno.Fecha_registro = al.Fecha_registro;
                try
                {
                    alumno.Proyecto_Residencia = al.Proyecto_Residencia;
                }
                catch { }
                //if (alumno.Proyecto_Residencia.IdAsesorInterno.HasValue) {
                  //  MessageBox.Show(alumno.Proyecto_Residencia.IdAsesorInterno.ToString());
                    //using (var con = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {

                      //  alumno.Proyecto_Residencia= con.Asesor_Interno.FirstOrDefault(x=>x.IdAsesor==alumno.Proyecto_Residencia.IdAsesorInterno);
                    //}
                //}
               

            }
            catch (Exception ex)
            {
                Errores ="adigando"+ ex.Message;
            }
            try
            {

                alumno.RegisterObserver(out Errores);



            }
            catch (Exception ex)
            {
                Errores = "guardando"+ex.Message;

            }
        }

    }
}
