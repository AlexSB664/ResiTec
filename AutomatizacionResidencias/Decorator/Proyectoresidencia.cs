using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace AutomatizacionResidencias.Decorator
{
    public class Proyectoresidencia : Agregados
    {
        public override string getdatos()
        {
            return JsonConvert.SerializeObject(alumno.Proyecto_Residencia);
        }


        public override void Registrardatos(string datos,out string Errores)
        {
            Errores = null;
            var proyecto = JsonConvert.DeserializeObject<Proyecto_Residencia>(datos);
            alumno.Proyecto_Residencia = proyecto;

            alumno.Proyecto_Residencia.RegisterObserver(out Errores);
        }
    }
}
