using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizacionResidencias.Acciones;
namespace AutomatizacionResidencias
{
    public class AlumnoObserver : IObserver
    {
        public string Correo { get; set; }

        public void Update()
        {
            Enviarcorreo enviar = new Enviarcorreo();
            enviar.correo = Correo;
            enviar.enviar();
           
        }
    }
}
