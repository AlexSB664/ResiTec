﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutomatizacionResidencias.Decorator
{
    public class Datosalumno : REGISTRO
    {
        public override void Registrardatos(string datos,out string Errores)
        {
            try
            {
                Errores = null;
                var al = JsonConvert.DeserializeObject<Alumno>(datos);

                alumno.NoControl = al.NoControl;
                alumno.Nombre = al.Nombre;
                alumno.Semestre = al.Semestre;
                alumno.Telefono = al.Telefono;
                alumno.Correo = al.Correo;
                alumno.Apellido_Paterno = al.Apellido_Paterno;
                alumno.Apellido_Materno = al.Apellido_Materno;
                alumno.Usuario = al.Usuario;
                alumno.Proyecto_Residencia = al.Proyecto_Residencia;
            }
            catch(Exception ex) {
                Errores = ex.InnerException.Message;
            }
            try
            {
                
                    alumno.RegisterObserver(out Errores);


                
            }
            catch(Exception ex)
                {
                Errores = ex.Message;

            }
        }




        public  void Registrardatosresidenciaelegida(string datos, out string Errores)
        {
            try
            {
                Errores = null;
                var al = JsonConvert.DeserializeObject<Alumno>(datos);

                alumno.NoControl = al.NoControl;
                alumno.Nombre = al.Nombre;
                alumno.Semestre = al.Semestre;
                alumno.Telefono = al.Telefono;
                alumno.Correo = al.Correo;
                alumno.Apellido_Paterno = al.Apellido_Paterno;
                alumno.Apellido_Materno = al.Apellido_Materno;
                alumno.Usuario = al.Usuario;
                alumno.NoProyecto = al.NoProyecto;
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }
            try
            {

                alumno.RegisterObserver(out Errores);



            }
            catch (Exception ex)
            {
                Errores = ex.Message;

            }
        }

    }
}
