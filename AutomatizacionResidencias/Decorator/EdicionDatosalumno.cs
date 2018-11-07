using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace AutomatizacionResidencias.Decorator
{
    class EdicionDatosalumno : REGISTRO
    {
        public override void Registrardatos(string datos)
        {
            var alumno = JsonConvert.DeserializeObject<Alumno>(datos);
            var anteriores = JsonConvert.SerializeObject(alumno);
            Administrador bitacora = new Administrador();
            string nuevosdatos = "";
            alumno.ActualizarDatosAlumno(nuevosdatos);
           
            
        }
    }
}
