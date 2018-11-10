using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutomatizacionResidencias.Decorator
{
    public abstract class REGISTRO
    {
        public AutomatizacionResidencias.Alumno alumno = new AutomatizacionResidencias.Alumno();
        public abstract void Registrardatos(string datos,out string Errores);
        string description;
        public string getdatos() {
            description = "No hay datos de alumno";
            return description;
        }

        public void notificarregistro() {
            alumno.NotifyObserver();
        }

        public string MostrarNip() {
            return alumno.Usuario.Password;
        }
    }
}
