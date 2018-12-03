using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using AutomatizacionResidencias.Acciones;
using AutomatizacionResidencias;
using System.Windows.Forms;

namespace AutomatizacionResidencias
{

    public partial class Alumno : Subject
    {
        public void NotifyObserver(out string Errores)
        {
            Errores = "";
            
            Enviarcorreo e = new Enviarcorreo();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                e.password = context.Usuario.FirstOrDefault(x=>x.Usuario1==this.Correo).Password;
            }
                e.correo = this.Correo;
            e.enviar();
             
        }

        public void RegisterObserver(out string Errores)
        {
            Errores = "";

            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                if (context.Alumno.Any(x => x.NoControl == this.NoControl)) {
                    Errores = "Ya existe un alumno con este numero de control";
                } else {
                    if (context.Usuario.Any(x => x.Usuario1 == this.Correo)) {
                        Errores = "Ya existe un Alumno con este correo";
                    }
                    else {

                        Random r = new Random();
                        this.Usuario.Password =(r.Next(10000,99999).ToString());
                   
                        
                        context.Usuario.Add(this.Usuario);
                        if (this.Proyecto_Residencia!=null) {
                            if (this.Proyecto_Residencia.IdAsesorInterno.HasValue) {

                                context.Set<Asesor_Interno>().Attach(Proyecto_Residencia.Asesor_Interno);

                            }

                        }
                        context.Alumno.Add(this);
                        context.SaveChanges();
                        MessageBox.Show("Pin alumno: "+Usuario.Password);
                        NotifyObserver(out Errores);

                    }
                }

            }

        }

        public void RemoveObserver(out string Errores)
        {
            Errores = "";
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                Alumno tem = context.Alumno.First(x => x.NoControl == this.NoControl);


                context.Alumno.Remove(tem);
                context.SaveChanges();
            }
            NotifyObserver(out Errores);
        }

        public void ActualizarDatosAlumno(string nuevosdatos, out string Errores) {
            Errores = "";
            Administrador a = new Administrador();
            var al = JsonConvert.DeserializeObject<Alumno>(nuevosdatos);
            a.Update();
            Alumno alumno = new Alumno();
            AlumnoObserver ao = new AlumnoObserver();
            ao.Correo = alumno.Correo;
            ao.Update();

            NotifyObserver(out Errores);
        }

   
    }

}
