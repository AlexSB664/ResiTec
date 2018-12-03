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
        public void actualizarstatus(int idstatus,int idproyecto,bool dictamen,bool anteproyecto,bool eval1,bool eval2,bool eval3,string comentario) {

            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                var proyecto = context.Proyecto_Residencia.FirstOrDefault(x=>x.No_Proyecto==idproyecto);
                proyecto.IdStatus = idstatus;
                proyecto.Dictamen = dictamen;
                proyecto.Status_Anteproyecto = anteproyecto;
                proyecto.Primera_Evaluacion = eval1;
                proyecto.Segunda_Evaluacion = eval2;
                proyecto.Tercera_Evaluacion = eval3;
                proyecto.Comentario = comentario;
                context.SaveChanges();

            }
        }

    }
}
