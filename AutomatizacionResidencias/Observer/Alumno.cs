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

    public partial class Alumno : Subject
    {
        public void NotifyObserver()
        {
            Enviarcorreo e = new Enviarcorreo();
            e.enviar();
             
        }

        public void RegisterObserver()
        {
           
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {

                context.Alumno.Add(this);
                context.SaveChanges();
            }

            NotifyObserver();
        }

        public void RemoveObserver()
        {
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                Alumno tem = context.Alumno.First(x => x.NoControl == this.NoControl);


                context.Alumno.Remove(tem);
                context.SaveChanges();
            }
            NotifyObserver();
        }

        public void ActualizarDatosAlumno(string nuevosdatos) {
            Administrador a = new Administrador();
            var al = JsonConvert.DeserializeObject<Alumno>(nuevosdatos);
            a.Update();
            Alumno alumno = new Alumno();
            AlumnoObserver ao = new AlumnoObserver();
            ao.Correo = alumno.Correo;
            ao.Update();

            NotifyObserver();
        }

   
    }

}
