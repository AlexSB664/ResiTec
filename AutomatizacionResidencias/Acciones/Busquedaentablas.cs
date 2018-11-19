﻿using System;
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
                residecias = (from r in context.Proyecto_Residencia select new Tablaproyecto { No_Proyecto = r.No_Proyecto,Asesorinterno=r.IdAsesorInterno,Cargo_Asesor_Externo=r.Cargo_Asesor_Externo,Correo_Asesor_Externo=r.Correo_Asesor_Externo,Nombre_Asesor_Externo=r.Nombre_Asesor_Externo,Telefono_Asesor_Externo=r.Telefono_Asesor_Externo,Fecha_Registro=r.Fecha_Registro,Nombre_de_la_Empresa=r.Nombre_de_la_Empresa,Nombre_Proyecto=r.Nombre_Proyecto,Periodo=r.Periodo,Status=r.IdStatus }).ToList();
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

    }
}
