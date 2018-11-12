using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionResidencias.Acciones
{
    
    public class Sugerencias
    {
        public List<Proyecto_Residencia> proyectosregistrados() {
            List<Proyecto_Residencia> residecias = new List<Proyecto_Residencia>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                residecias = context.Proyecto_Residencia.ToList();
            }
            return residecias;

        }

        public List<Asesor_Interno> Asesoresinternos()
        {
            List<Asesor_Interno> asesores = new List<Asesor_Interno>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                asesores = context.Asesor_Interno.ToList();
            }
            return asesores;
        }


        public List<Alumno> Alumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = context.Alumno.ToList();
            }
            return alumnos;
        }
    }
}
