using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatizacionResidencias.Acciones
{
    public class Busquedaentablas
    {
        public List<Tablaproyecto> proyectosregistrados()
        {
            List<Tablaproyecto> residecias = new List<Tablaproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                residecias = (from r in context.Proyecto_Residencia.Include("Status").Include("Periodos").Include("Asesor_Interno")

                              select new Tablaproyecto { No_Proyecto = r.No_Proyecto, Asesorinterno = r.IdAsesorInterno, Cargo_Asesor_Externo = r.Cargo_Asesor_Externo, Correo_Asesor_Externo = r.Correo_Asesor_Externo, Nombre_Asesor_Externo = r.Nombre_Asesor_Externo, Telefono_Asesor_Externo = r.Telefono_Asesor_Externo, Fecha_Registro = r.Fecha_Registro, Nombre_de_la_Empresa = r.Nombre_de_la_Empresa, Nombre_Proyecto = r.Nombre_Proyecto, Periodo = r.Periodo, Status = r.IdStatus, color = r.Status.Color, Anteproyecto = r.Status_Anteproyecto, Area = r.Area_del_Proyecto, Dictamen = r.Dictamen, Evalacion_1 = r.Primera_Evaluacion, Evaluacion_2 = r.Segunda_Evaluacion, Evaluacion_3 = r.Tercera_Evaluacion, statusn = r.Status.Nombre,Nombre_Asesor_interno=r.Asesor_Interno.Nombre,correo_asesor_interno=r.Asesor_Interno.Correo,Telefono_Asesor_interno=r.Asesor_Interno.Correo }).ToList();
                foreach (var row in residecias) {
                    if (row.Periodo!=null) {
                     var per  = context.Periodos.FirstOrDefault(x=>x.Idperiodo==row.Periodo);
                        if (per.periodo==true) {
                            row.Periodo_año = "JUL-DIC "+per.año;
                        }
                        if(per.periodo==false){
                            row.Periodo_año = "ENE-JUN " + per.año;

                        }
                    }

                }


            }
            return residecias;

        }

        public List<Tablaproyecto> proyectosregistradossinasignar()
        {
            List<Tablaproyecto> residecias = new List<Tablaproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                // residecias = (from r in context.Proyecto_Residencia where !context.HorarioPresentacion.Any(x => x.No_Proyecto == r.No_Proyecto) select new Tablaproyecto { No_Proyecto = r.No_Proyecto, Asesorinterno = r.IdAsesorInterno, Cargo_Asesor_Externo = r.Cargo_Asesor_Externo, Correo_Asesor_Externo = r.Correo_Asesor_Externo, Nombre_Asesor_Externo = r.Nombre_Asesor_Externo, Telefono_Asesor_Externo = r.Telefono_Asesor_Externo, Fecha_Registro = r.Fecha_Registro, Nombre_de_la_Empresa = r.Nombre_de_la_Empresa, Nombre_Proyecto = r.Nombre_Proyecto, Periodo = r.Periodo, Status = r.IdStatus, color = null }).ToList();



                residecias = (from r in context.Proyecto_Residencia
                              .Include("Status").Include("Periodos").Include("Asesor_Interno")
                              where !context.HorarioPresentacion.Any(x => x.No_Proyecto == r.No_Proyecto)
                              select new Tablaproyecto { No_Proyecto = r.No_Proyecto, Asesorinterno = r.IdAsesorInterno, Cargo_Asesor_Externo = r.Cargo_Asesor_Externo, Correo_Asesor_Externo = r.Correo_Asesor_Externo, Nombre_Asesor_Externo = r.Nombre_Asesor_Externo, Telefono_Asesor_Externo = r.Telefono_Asesor_Externo, Fecha_Registro = r.Fecha_Registro, Nombre_de_la_Empresa = r.Nombre_de_la_Empresa, Nombre_Proyecto = r.Nombre_Proyecto, Periodo = r.Periodo, Status = r.IdStatus, color = r.Status.Color, Anteproyecto = r.Status_Anteproyecto, Area = r.Area_del_Proyecto, Dictamen = r.Dictamen, Evalacion_1 = r.Primera_Evaluacion, Evaluacion_2 = r.Segunda_Evaluacion, Evaluacion_3 = r.Tercera_Evaluacion, statusn = r.Status.Nombre, Nombre_Asesor_interno = r.Asesor_Interno.Nombre, correo_asesor_interno = r.Asesor_Interno.Correo, Telefono_Asesor_interno = r.Asesor_Interno.Correo }).ToList();
                foreach (var row in residecias)
                {
                    if (row.Periodo != null)
                    {
                        var per = context.Periodos.FirstOrDefault(x => x.Idperiodo == row.Periodo);
                        if (per.periodo == true)
                        {
                            row.Periodo_año = "JUL-DIC " + per.año;
                        }
                        if (per.periodo == false)
                        {
                            row.Periodo_año = "ENE-JUN " + per.año;

                        }
                    }

                }
            }
            return residecias;

        }

        public Tablaproyecto Proyectoespecifico(int? Noproyecto)
        {
            Tablaproyecto residecias = new Tablaproyecto();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                residecias = (from r in context.Proyecto_Residencia where Noproyecto == r.No_Proyecto select new Tablaproyecto { No_Proyecto = r.No_Proyecto, Asesorinterno = r.IdAsesorInterno, Cargo_Asesor_Externo = r.Cargo_Asesor_Externo, Correo_Asesor_Externo = r.Correo_Asesor_Externo, Nombre_Asesor_Externo = r.Nombre_Asesor_Externo, Telefono_Asesor_Externo = r.Telefono_Asesor_Externo, Fecha_Registro = r.Fecha_Registro, Nombre_de_la_Empresa = r.Nombre_de_la_Empresa, Nombre_Proyecto = r.Nombre_Proyecto, Periodo = r.Periodo, Status = r.IdStatus, color = null }).ToList()[0];





                var status = context.Status.FirstOrDefault(x => x.IdStatus == residecias.Status);
                if (status != null)
                {
                    residecias.color = status.Color;
                    residecias.statusn = status.Descripcion;
                }


            }
            return residecias;

        }


        public List<statusdeproyecto> statusdeproyectos()
        {
            List<statusdeproyecto> residecias = new List<statusdeproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                residecias = (from r in context.Status select new statusdeproyecto { IdStatus = r.IdStatus, nombre = r.Nombre, Descripcion = r.Descripcion, Color = r.Color }).ToList();
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
                alumnos = (from r in context.Alumno select new TablaAlumno { NoControl = r.NoControl, Apellido_Materno = r.Apellido_Materno, Apellido_Paterno = r.Apellido_Paterno, Correo = r.Correo, Nombre = r.Nombre, NoProyecto = r.NoProyecto, Semestre = r.Semestre, Telefono = r.Telefono,Genero=r.Genero,Fecha_registro=r.Fecha_registro }).ToList();
            }
            return alumnos;
        }



        public List<TablaAsesor> Asesores()
        {
            List<TablaAsesor> alumnos = new List<TablaAsesor>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = (from r in context.Asesor_Interno select new TablaAsesor { IdAsesor = r.IdAsesor, Correo = r.Correo, Nombre = r.Nombre, Telefono = r.Telefono, Turno = r.Turno }).ToList();
            }
            return alumnos;
        }

        public Proyecto_Residencia proyectodetalles(int noproyecto)
        {
            Proyecto_Residencia alumnos = new Proyecto_Residencia();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = context.Proyecto_Residencia
                    .Include("Asesor_Interno")
                      .Include("Status")
                      .Include("Periodos")
                    .FirstOrDefault(x => x.No_Proyecto == noproyecto);
            }
            return alumnos;
        }

        public List<Tablaproyecto> Busquedadeproyectos(int Noproyecto)
        {
            List<Tablaproyecto> residecias = new List<Tablaproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {

                // residecias = context.Proyecto_Residencia.Contains()
                residecias = (from r in context.Proyecto_Residencia where r.No_Proyecto == Noproyecto select new Tablaproyecto { No_Proyecto = r.No_Proyecto, Asesorinterno = r.IdAsesorInterno, Cargo_Asesor_Externo = r.Cargo_Asesor_Externo, Correo_Asesor_Externo = r.Correo_Asesor_Externo, Nombre_Asesor_Externo = r.Nombre_Asesor_Externo, Telefono_Asesor_Externo = r.Telefono_Asesor_Externo, Fecha_Registro = r.Fecha_Registro, Nombre_de_la_Empresa = r.Nombre_de_la_Empresa, Nombre_Proyecto = r.Nombre_Proyecto, Periodo = r.Periodo, Status = r.IdStatus, color = null }).ToList();

                foreach (var r in residecias)
                {
                    var status = context.Status.FirstOrDefault(x => x.IdStatus == r.Status);
                    if (status != null)
                    {
                        r.color = status.Color;
                        r.statusn = status.Descripcion;
                    }
                }

            }
            return residecias;

        }

        public List<TablaAlumno> Busquedaalumno(int? Nocontrol, string Nombre)
        {
            List<TablaAlumno> alumnos = new List<TablaAlumno>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                if (Nocontrol != null) {
                    alumnos = (from r in context.Alumno where r.NoControl == Nocontrol select new TablaAlumno { NoControl = r.NoControl, Apellido_Materno = r.Apellido_Materno, Apellido_Paterno = r.Apellido_Paterno, Correo = r.Correo, Nombre = r.Nombre, NoProyecto = r.NoProyecto, Semestre = r.Semestre, Telefono = r.Telefono }).ToList();
                }

                if (Nocontrol == null && Nombre != null)
                {
                    alumnos = (from r in context.Alumno where r.Nombre == Nombre select new TablaAlumno { NoControl = r.NoControl, Apellido_Materno = r.Apellido_Materno, Apellido_Paterno = r.Apellido_Paterno, Correo = r.Correo, Nombre = r.Nombre, NoProyecto = r.NoProyecto, Semestre = r.Semestre, Telefono = r.Telefono }).ToList();
                }


            }
            return alumnos;
        }


        public List<ComboGrupo> todosgrupos()
        {
            List<ComboGrupo> alumnos = new List<ComboGrupo>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {

                alumnos = (from r in context.Grupos select new ComboGrupo { IdGrupo = r.IdGrupo, Nombre = r.Nombre, Descripcion = r.Descripcion }).ToList();



            }
            return alumnos;
        }


        public List<TablaHorario> horariosengrupos(int idgrupo)
        {
            List<TablaHorario> alumnos = new List<TablaHorario>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {

                alumnos = (from r in context.HorarioPresentacion where r.Id_Grupo == idgrupo select new TablaHorario { No_proyecto = r.No_Proyecto, Fecha = r.Fecha, HoraFin = r.HoraFin, Horainicio = r.Horainicio, IdGrupo = r.Id_Grupo, IdPresentacion = r.IdPresentacion }).ToList();



            }
            return alumnos;
        }


        public List<TablaAlumno> alumnosporproyecto(int? Noproyecto)
        {
            List<TablaAlumno> alumnos = new List<TablaAlumno>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                if (Noproyecto != null)
                {
                    alumnos = (from r in context.Alumno where r.NoProyecto == Noproyecto select new TablaAlumno { NoControl = r.NoControl, Apellido_Materno = r.Apellido_Materno, Apellido_Paterno = r.Apellido_Paterno, Correo = r.Correo, Nombre = r.Nombre, NoProyecto = r.NoProyecto, Semestre = r.Semestre, Telefono = r.Telefono,Genero=r.Genero,Fecha_registro=r.Fecha_registro }).ToList();
                }




            }
            return alumnos;
        }


        public Asesor_Interno Buscarasesorinternoespecifico(int asesoriid)
        {
            Asesor_Interno asesores = new Asesor_Interno();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                asesores = context.Asesor_Interno.FirstOrDefault(x => x.IdAsesor == asesoriid);
            }
            return asesores;
        }


        public List<Tablaproyecto> Proyectosporasesor(int Idasesor)
        {
            List<Tablaproyecto> residecias = new List<Tablaproyecto>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {

                // residecias = context.Proyecto_Residencia.Contains()
                residecias = (from r in context.Proyecto_Residencia
                            
                              .Include("Status").Include("Periodos").Include("Asesor_Interno")
                              where r.IdAsesorInterno == Idasesor
                              select new Tablaproyecto { No_Proyecto = r.No_Proyecto, Asesorinterno = r.IdAsesorInterno, Cargo_Asesor_Externo = r.Cargo_Asesor_Externo, Correo_Asesor_Externo = r.Correo_Asesor_Externo, Nombre_Asesor_Externo = r.Nombre_Asesor_Externo, Telefono_Asesor_Externo = r.Telefono_Asesor_Externo, Fecha_Registro = r.Fecha_Registro, Nombre_de_la_Empresa = r.Nombre_de_la_Empresa, Nombre_Proyecto = r.Nombre_Proyecto, Periodo = r.Periodo, Status = r.IdStatus, color = r.Status.Color, Anteproyecto = r.Status_Anteproyecto, Area = r.Area_del_Proyecto, Dictamen = r.Dictamen, Evalacion_1 = r.Primera_Evaluacion, Evaluacion_2 = r.Segunda_Evaluacion, Evaluacion_3 = r.Tercera_Evaluacion, statusn = r.Status.Nombre, Nombre_Asesor_interno = r.Asesor_Interno.Nombre, correo_asesor_interno = r.Asesor_Interno.Correo, Telefono_Asesor_interno = r.Asesor_Interno.Correo }).ToList();
                foreach (var row in residecias)
                {
                    if (row.Periodo != null)
                    {
                        var per = context.Periodos.FirstOrDefault(x => x.Idperiodo == row.Periodo);
                        if (per.periodo == true)
                        {
                            row.Periodo_año = "JUL-DIC " + per.año;
                        }
                        if (per.periodo == false)
                        {
                            row.Periodo_año = "ENE-JUN " + per.año;

                        }
                    }

                }

            }
            return residecias;

        }


        public List<Tablaperiodo> periodos() {
            List<Tablaperiodo> periodos = new List<Tablaperiodo>();
            try
            {
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                    var temp = context.Periodos.ToList();

                    foreach (var t in temp) {

                        periodos.Add(new Tablaperiodo {idperiodo=t.Idperiodo,periodo=Periodoque(t.periodo,t.año.ToString()) });
                    }
                }
            }
            catch { }
            return periodos;
        }


        public AutomatizacionResidencias.Periodos periodoactual() {
            AutomatizacionResidencias.Periodos peri =new AutomatizacionResidencias.Periodos();
            try
            {
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var p = int.Parse(context.Params.FirstOrDefault(x => x.Llave == "Periodoactual").Valor);
                    peri = context.Periodos.FirstOrDefault(x => x.Idperiodo == p);

                }
            }
            catch { }
            return peri;
        }
       

        public string Periodoque(bool? periodo,string year){

            if (periodo == true) { return "JUL-DEC " + year; } else {
                if (periodo == false) { return "ENE-JUN " + year; } else {
                    return "";
                }
            }



        }


        public List<Tabladatos> Exportardatos()
        {
            List<Tabladatos> alumnos = new List<Tabladatos>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                alumnos = (from r in context.Alumno
                           .Include("Proyecto_Residencia")
                           select new Tabladatos { NoControl = r.NoControl, Apellido_Materno = r.Apellido_Materno, Apellido_Paterno = r.Apellido_Paterno, Correo = r.Correo, Nombre = r.Nombre, NoProyecto = r.NoProyecto, Semestre = r.Semestre, Telefono = r.Telefono, Genero = r.Genero, Fecha_registro = r.Fecha_registro,Anteproyecto=r.Proyecto_Residencia.Status_Anteproyecto,Area=r.Proyecto_Residencia.Area_del_Proyecto,Cargo_Asesor_Externo=r.Proyecto_Residencia.Cargo_Asesor_Externo,Correo_Asesor_Externo=r.Proyecto_Residencia.Correo_Asesor_Externo,Dictamen=r.Proyecto_Residencia.Dictamen,Evalacion_1=r.Proyecto_Residencia.Primera_Evaluacion,Evaluacion_2=r.Proyecto_Residencia.Segunda_Evaluacion,Evaluacion_3=r.Proyecto_Residencia.Tercera_Evaluacion,Nombre_Asesor_Externo=r.Proyecto_Residencia.Nombre_Asesor_Externo,Nombre_de_la_Empresa=r.Proyecto_Residencia.Nombre_de_la_Empresa,Nombre_Proyecto=r.Proyecto_Residencia.Nombre_Proyecto,Telefono_Asesor_Externo=r.Proyecto_Residencia.Telefono_Asesor_Externo,Periodo=r.Proyecto_Residencia.Periodo,Status=r.Proyecto_Residencia.IdStatus,Fecha_Registro=r.Proyecto_Residencia.Fecha_Registro }).ToList();

                foreach (var row in alumnos)
                {
                    if (row.Periodo != null)
                    {
                        var per = context.Periodos.FirstOrDefault(x => x.Idperiodo == row.Periodo);
                        if (per.periodo == true)
                        {
                            row.Periodo_año = "JUL-DIC " + per.año;
                        }
                        if (per.periodo == false)
                        {
                            row.Periodo_año = "ENE-JUN " + per.año;

                        }
                    }
                }
            }
            return alumnos;

        }



    }

    public delegate void addperiodo();
}
