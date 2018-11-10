using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace AutomatizacionResidencias.Decorator
{
    public class Usuario : Agregados
    {
        public override string getdatos()
        {
            return JsonConvert.SerializeObject(alumno.Usuario);
        }
        public override void Registrardatos(string datos,out string Errores)
        {
            Errores = null;
            using (var context = new ResidenciasEntities()) {
                alumno.Usuario.Password =context.generarnip().ToString();
            }
        }
    }
}
