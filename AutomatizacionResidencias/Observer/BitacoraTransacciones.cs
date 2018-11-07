using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutomatizacionResidencias.Acciones;
namespace AutomatizacionResidencias
{
    public partial class Administrador : IObserver
    {
        public BitacoraTransacciones Transaccion;

        public void Update()
        {
          
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                context.BitacoraTransacciones.Add(Transaccion);
               context.SaveChanges();
            }


        }
    }
}
