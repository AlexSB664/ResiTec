using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionResidencias.Acciones
{
    public class Busquedaentablas
    {
        public List<Tablaproyecto> proyectosregistrados()
        {
            List<Tablaproyecto> residecias = new List<Tablaproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                residecias = (from r in context.Proyecto_Residencia  select new Tablaproyecto { No_Proyecto = r.No_Proyecto,Asesorinterno=r.IdAsesorInterno,Cargo_Asesor_Externo=r.Cargo_Asesor_Externo,Correo_Asesor_Externo=r.Correo_Asesor_Externo,Nombre_Asesor_Externo=r.Nombre_Asesor_Externo,Telefono_Asesor_Externo=r.Telefono_Asesor_Externo,Fecha_Registro=r.Fecha_Registro,Nombre_de_la_Empresa=r.Nombre_de_la_Empresa,Nombre_Proyecto=r.Nombre_Proyecto,Periodo=r.Periodo,Status=r.IdStatus,color=null }).ToList();

                foreach (var r in residecias) {
                    var status = context.Status.FirstOrDefault(x=>x.IdStatus==r.Status);
                    if (status!=null) {
                        r.color = status.Color;
                        r.status = status.Descripcion;
                    }
                }

            }
            return residecias;

        }

        public List<statusdeproyecto> statusdeproyectos()
        {
            List<statusdeproyecto> residecias = new List<statusdeproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                residecias = (from r in context.Status select new statusdeproyecto {IdStatus = r.IdStatus,nombre=r.Nombre,Descripcion=r.Descripcion,Color=r.Color}).ToList();
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


        public List<TablaAlumno> Alumnos()
        {
            List<TablaAlumno> alumnos = new List<TablaAlumno>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = (from r in context.Alumno select  new TablaAlumno { NoControl=r.NoControl,Apellido_Materno=r.Apellido_Materno,Apellido_Paterno=r.Apellido_Paterno,Correo=r.Correo,Nombre=r.Nombre,NoProyecto=r.NoProyecto,Semestre=r.Semestre,Telefono=r.Telefono}).ToList();
            }
            return alumnos;
        }



        public List<TablaAsesor> Asesores()
        {
            List<TablaAsesor> alumnos = new List<TablaAsesor>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = (from r in context.Asesor_Interno select new TablaAsesor {IdAsesor=r.IdAsesor,Correo=r.Correo,Nombre=r.Nombre,Telefono=r.Telefono,Turno=r.Turno}).ToList();
            }
            return alumnos;
        }

        public Proyecto_Residencia proyectodetalles(int noproyecto)
        {
            Proyecto_Residencia alumnos = new Proyecto_Residencia();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = context.Proyecto_Residencia.FirstOrDefault(x=>x.No_Proyecto==noproyecto);
            }
            return alumnos;
        }

        public List<Tablaproyecto> Busquedadeproyectos(int Noproyecto)
        {
            List<Tablaproyecto> residecias = new List<Tablaproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                residecias = (from r in context.Proyecto_Residencia where r.No_Proyecto==Noproyecto select new Tablaproyecto { No_Proyecto = r.No_Proyecto, Asesorinterno = r.IdAsesorInterno, Cargo_Asesor_Externo = r.Cargo_Asesor_Externo, Correo_Asesor_Externo = r.Correo_Asesor_Externo, Nombre_Asesor_Externo = r.Nombre_Asesor_Externo, Telefono_Asesor_Externo = r.Telefono_Asesor_Externo, Fecha_Registro = r.Fecha_Registro, Nombre_de_la_Empresa = r.Nombre_de_la_Empresa, Nombre_Proyecto = r.Nombre_Proyecto, Periodo = r.Periodo, Status = r.IdStatus, color = null }).ToList();

                foreach (var r in residecias)
                {
                    var status = context.Status.FirstOrDefault(x => x.IdStatus == r.Status);
                    if (status != null)
                    {
                        r.color = status.Color;
                        r.status = status.Descripcion;
                    }
                }

            }
            return residecias;

        }

        public List<TablaAlumno> Busquedaalumno(int? Nocontrol,string Nombre)
        {
            List<TablaAlumno> alumnos = new List<TablaAlumno>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                if (Nocontrol!=null && Nombre==null) {
                    alumnos = (from r in context.Alumno where r.NoControl == Nocontrol select new TablaAlumno { NoControl = r.NoControl, Apellido_Materno = r.Apellido_Materno, Apellido_Paterno = r.Apellido_Paterno, Correo = r.Correo, Nombre = r.Nombre, NoProyecto = r.NoProyecto, Semestre = r.Semestre, Telefono = r.Telefono }).ToList();
                }

                if (Nocontrol == null && Nombre != null)
                {
                    alumnos = (from r in context.Alumno where r.Nombre == Nombre select new TablaAlumno { NoControl = r.NoControl, Apellido_Materno = r.Apellido_Materno, Apellido_Paterno = r.Apellido_Paterno, Correo = r.Correo, Nombre = r.Nombre, NoProyecto = r.NoProyecto, Semestre = r.Semestre, Telefono = r.Telefono }).ToList();
                }


            }
            return alumnos;
        }

     

    }
}
