using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizacionResidencias;
namespace AutomatizacionResidencias.Acciones
{
    public class Cambiar_status
    {
        public void actualizarstatus(int idstatus,int idproyecto) {

            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                var proyecto = context.Proyecto_Residencia.FirstOrDefault(x=>x.No_Proyecto==idproyecto);
                proyecto.IdStatus = idstatus;
                context.SaveChanges();

            }
        }

    }
}
