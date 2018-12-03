using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomatizacionResidencias;
using AutomatizacionResidencias.Acciones;
namespace AutomatizacionResidencias.Acciones
{
    public class Eliminar
    {
        public bool Eliminaralumno(int Nocontrol,out string Errores){
            try
            {
                Errores = "";
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var alumno = context.Alumno.FirstOrDefault(x=>x.NoControl==Nocontrol);

                    context.Alumno.Remove(alumno);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex) {
                Errores = ex.Message;
                return false;
            }
        }

        public bool Eliminarresidencia(int Noproyecto, out string Errores)
        {
            try
            {
                Errores = "";
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var proyecto = context.Proyecto_Residencia.FirstOrDefault(x => x.No_Proyecto == Noproyecto);

                    var alumnos = context.Alumno.Where(x=>x.NoProyecto==proyecto.No_Proyecto);
                    var horariospresentacion = context.HorarioPresentacion.Where(x=>x.No_Proyecto==proyecto.No_Proyecto);
                    var bitacoratransacciones = context.BitacoraTransacciones.Where(x=>x.No_Proyecto==proyecto.No_Proyecto);

                    foreach (var alu in alumnos) {
                        alu.NoProyecto = null;

                    }

                    context.BitacoraTransacciones.RemoveRange(bitacoratransacciones);
                    context.HorarioPresentacion.RemoveRange(horariospresentacion);
                    context.Proyecto_Residencia.Remove(proyecto);
                    
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
                return false;
            }
        }

        public bool Eliminarresidenciaconalumnos(int Noproyecto, out string Errores)
        {
            try
            {
                Errores = "";
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var proyecto = context.Proyecto_Residencia.FirstOrDefault(x => x.No_Proyecto == Noproyecto);
                    var alumnos = context.Alumno.Where(x => x.NoProyecto == proyecto.No_Proyecto);
                    var horariospresentacion = context.HorarioPresentacion.Where(x => x.No_Proyecto == proyecto.No_Proyecto);
                    var bitacoratransacciones = context.BitacoraTransacciones.Where(x => x.No_Proyecto == proyecto.No_Proyecto);
                    context.Alumno.RemoveRange(alumnos);
                    context.BitacoraTransacciones.RemoveRange(bitacoratransacciones);
                    context.HorarioPresentacion.RemoveRange(horariospresentacion);
                    context.Proyecto_Residencia.Remove(proyecto);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
                return false;
            }
        }

        public bool Eliminarasesor(int idasesor, out string Errores)
        {
            try
            {
                Errores = "";
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var asesor = context.Asesor_Interno.FirstOrDefault(x => x.IdAsesor == idasesor);

                    var proyectos = context.Proyecto_Residencia.Where(x=>x.IdAsesorInterno==idasesor);

                    foreach (var p in proyectos) {
                        p.IdAsesorInterno = null;
                    }

                    context.Asesor_Interno.Remove(asesor);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
                return false;
            }
        }

        public bool Eliminargrupoexposicion(int idgrupo, out string Errores)
        {
            try
            {
                Errores = "";
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var grupo = context.Grupos.FirstOrDefault(x => x.IdGrupo== idgrupo);
                    var horarios = context.HorarioPresentacion.Where(x=>x.Id_Grupo==idgrupo);
                    context.HorarioPresentacion.RemoveRange(horarios);
                    context.Grupos.Remove(grupo);
                    
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
                return false;
            }
        }


        public bool Eliminarstatus(int idstatus, out string Errores)
        {
            try
            {
                Errores = "";
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var Status = context.Status.FirstOrDefault(x => x.IdStatus == idstatus);

                    var proyectos = context.Proyecto_Residencia.Where(x=>x.IdStatus==Status.IdStatus);

                    foreach (var p in proyectos) {
                        p.IdStatus = null;
                    }

                    context.Status.Remove(Status);

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
                return false;
            }
        }

        public bool Eliminarperiodos(int idperiodo, out string Errores)
        {
            try
            {
                Errores = "";
                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    var Status = context.Periodos.FirstOrDefault(x => x.Idperiodo == idperiodo);

                    context.Periodos.Remove(Status);

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
                return false;
            }
        }
    }
}
