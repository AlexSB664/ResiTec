using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
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


        public List<Status> status()
        {
            List<Status> alumnos = new List<Status>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = context.Status.Include("Proyecto_Residencia").ToList();
            }
            return alumnos;
        }



        public bool salvarhorario(List<HorarioPresentacion> item,int grupoid) {
            try
            {
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var yaexistentes = context.HorarioPresentacion.Where(x=>x.Id_Grupo==grupoid);
                    context.HorarioPresentacion.RemoveRange(yaexistentes);
                    context.SaveChanges();

                    context.HorarioPresentacion.AddRange(item);
                    context.SaveChanges();

                    try {
                        var grupo = context.Grupos.FirstOrDefault(x=>x.IdGrupo==item[0].Id_Grupo);

                        MessageBox.Show(JsonConvert.SerializeObject(grupo));
                        grupo.Fechainicio = item.OrderBy(x=>x.Fecha).ToList()[0].Fecha;
                        grupo.Fechafin = item.OrderByDescending(x=>x.Fecha).ToList()[0].Fecha;
                        context.SaveChanges();


                    }
                    catch(Exception ex) {
                       // MessageBox.Show(ex.Message);
                    }
                    return true;
                }


             }
            catch(Exception ex) {
                MessageBox.Show(ex.InnerException.InnerException.Message);
                return false;
            }
        }



        

    }
}
