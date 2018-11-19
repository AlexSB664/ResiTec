using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutomatizacionResidencias;
namespace AutomatizacionResidencias.Decorator
{
    public class Status : Agregados
    {
        public override string getdatos()
        {
            throw new NotImplementedException();
        }

        public override void Registrardatos(string datos, out string Errores)
        {
            Errores = null;

            var status = JsonConvert.DeserializeObject<AutomatizacionResidencias.Status>(datos);

            using (var context =new ResidenciasEntities(new Acciones.Conexion().returnconexion().ConnectionString)) {
                context.Status.Add(status);
                context.SaveChanges();
            }
        }
    }
}
