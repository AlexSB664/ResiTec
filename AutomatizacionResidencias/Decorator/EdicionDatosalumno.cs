using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutomatizacionResidencias;
namespace AutomatizacionResidencias.Decorator
{
    public class EdicionDatosalumno : REGISTRO
    {
        public override void Registrardatos(string datos, out string Errores)
        {
            Errores = null;
            var alumno = JsonConvert.DeserializeObject<Alumno>(datos);
            var anteriores = JsonConvert.SerializeObject(alumno);
            Administrador bitacora = new Administrador();
            string nuevosdatos = "";
            alumno.ActualizarDatosAlumno(nuevosdatos, out Errores);


        }

        public void buscaralumno(string correo){
            using (var context = new ResidenciasEntities(new AutomatizacionResidencias.Acciones.Conexion().returnconexion().ConnectionString )) {
                this.alumno = context.Alumno.FirstOrDefault(x=>x.Correo==correo);
            }


          
}

        public void Guardarcambios()
        {
            using (var context = new ResidenciasEntities(new AutomatizacionResidencias.Acciones.Conexion().returnconexion().ConnectionString))
            {
                var alumnoo = context.Alumno.FirstOrDefault(x => x.Correo == this.alumno.Correo);
                alumnoo.Nombre = this.alumno.Nombre;
                alumnoo.Semestre = this.alumno.Semestre;
                alumnoo.Telefono = this.alumno.Telefono;
                alumnoo.Apellido_Paterno = this.alumno.Apellido_Paterno;
                alumnoo.Apellido_Materno = this.alumno.Apellido_Materno;
                alumnoo.Correo = this.alumno.Correo;

                context.SaveChanges();
            }
        }
    }
}
