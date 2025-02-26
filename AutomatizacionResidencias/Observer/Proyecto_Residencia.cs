﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizacionResidencias.Acciones;
using Newtonsoft.Json;
namespace AutomatizacionResidencias
{
    public partial class Proyecto_Residencia : Subject
    {
        public void NotifyObserver(out string Errores)
        {
            Errores = "";
      
        }

        public void RegisterObserver(out string Errores)
        {
            Errores = "";

            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {

                context.Proyecto_Residencia.Add(this);
                context.SaveChanges();
            }
            NotifyObserver(out Errores);
        }

        public void RemoveObserver(out string Errores)
        {
            Errores = "";

            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {

                context.Proyecto_Residencia.Remove(this);
                context.SaveChanges();
            }
            NotifyObserver(out Errores);
        }

        public void ActualizarDatosResidencia(string nuevosdatos, out string Errores) {
            Errores = "";

            Administrador a = new Administrador();
            var al = JsonConvert.DeserializeObject<Proyecto_Residencia>(nuevosdatos);
            a.Update();
            Proyecto_Residencia alumno = new Proyecto_Residencia();
            a.Update();

            NotifyObserver(out Errores);
        }
    }
}
