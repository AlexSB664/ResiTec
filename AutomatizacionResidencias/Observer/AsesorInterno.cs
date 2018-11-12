using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using AutomatizacionResidencias.Acciones;
using AutomatizacionResidencias;
namespace AutomatizacionResidencias
{
   public partial class Asesor_Interno:Subject
    {

        public void RegisterObserver(out string Errores)
        {
            Errores = "";

            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                        context.Asesor_Interno.Add(this);


                 
                        context.SaveChanges();

            

            }

        }

        public void RemoveObserver(out string Errores)
        {
            Errores = "";
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {


                context.Asesor_Interno.Remove(this);
                context.SaveChanges();
            }
            NotifyObserver(out Errores);
        }

        public void ActualizarDatosAlumno(string nuevosdatos, out string Errores)
        {
            Errores = "";
            Administrador a = new Administrador();
            var al = JsonConvert.DeserializeObject<Alumno>(nuevosdatos);
            a.Update();
            Alumno alumno = new Alumno();
            AlumnoObserver ao = new AlumnoObserver();
            ao.Correo = alumno.Correo;
            ao.Update();

            NotifyObserver(out Errores);
        }

        public void NotifyObserver(out string Errores)
        {
            Errores = "";

          

        }
    }
}
