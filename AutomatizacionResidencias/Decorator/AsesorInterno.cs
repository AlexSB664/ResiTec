using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace AutomatizacionResidencias.Decorator
{
    public class AsesorInterno : Agregados
    {
        public override string getdatos()
        {
            return JsonConvert.SerializeObject(alumno.Proyecto_Residencia.Asesor_Interno);
        }
        public override void Registrardatos(string datos)
        {
            var asesor = JsonConvert.DeserializeObject<Asesor_Interno>(datos);
            alumno.Proyecto_Residencia.Asesor_Interno = asesor;

        }
    }
}
