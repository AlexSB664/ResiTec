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
            int user = int.Parse(correo);
            using (var context = new ResidenciasEntities(new AutomatizacionResidencias.Acciones.Conexion().returnconexion().ConnectionString )) {
                try
                {
                    this.alumno = context.Alumno.FirstOrDefault(x => x.NoControl == user);
                }catch{
                }

                try
                {
                    this.alumno.Proyecto_Residencia = context.Proyecto_Residencia.FirstOrDefault(x => x.No_Proyecto == alumno.NoProyecto);
                }
                catch { }
                try
                {
                    this.alumno.Proyecto_Residencia.Asesor_Interno = context.Asesor_Interno.FirstOrDefault(x => x.IdAsesor == alumno.Proyecto_Residencia.IdAsesorInterno);
                }
                catch {

                }
                }
        }

        public void Guardarcambios()
        {
            using (var context = new ResidenciasEntities(new AutomatizacionResidencias.Acciones.Conexion().returnconexion().ConnectionString))
            {
                var alumnoo = context.Alumno.FirstOrDefault(x => x.Correo == this.alumno.Correo);
                var residencia = context.Proyecto_Residencia.FirstOrDefault(x=>x.No_Proyecto==this.alumno.NoProyecto);
                alumnoo.Nombre = this.alumno.Nombre;
                alumnoo.Semestre = this.alumno.Semestre;
                alumnoo.Telefono = this.alumno.Telefono;
                alumnoo.Apellido_Paterno = this.alumno.Apellido_Paterno;
                alumnoo.Apellido_Materno = this.alumno.Apellido_Materno;
                alumnoo.Correo = this.alumno.Correo;
                residencia.Nombre_Proyecto = this.alumno.Proyecto_Residencia.Nombre_Proyecto;
                residencia.Cargo_Asesor_Externo = this.alumno.Proyecto_Residencia.Cargo_Asesor_Externo;
                residencia.Correo_Asesor_Externo = this.alumno.Proyecto_Residencia.Correo_Asesor_Externo;
                residencia.Nombre_Asesor_Externo = this.alumno.Proyecto_Residencia.Nombre_Asesor_Externo;
                residencia.Nombre_de_la_Empresa = this.alumno.Proyecto_Residencia.Nombre_de_la_Empresa;
                residencia.Telefono_Asesor_Externo = this.alumno.Proyecto_Residencia.Telefono_Asesor_Externo;
                context.SaveChanges();
            }
        }
    }
}
//no puede pedir visa en la misma ciudad tambien vimos iterador