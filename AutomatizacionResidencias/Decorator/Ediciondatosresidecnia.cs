using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionResidencias.Decorator
{
    public class Ediciondatosresidecnia:REGISTRO
    {
        public void buscarresidencia(int NoProyecto)
        {
            Proyecto_Residencia pro = new Proyecto_Residencia();
            using (var context = new ResidenciasEntities(new AutomatizacionResidencias.Acciones.Conexion().returnconexion().ConnectionString))
            {
                this.alumno.Proyecto_Residencia = context.Proyecto_Residencia.FirstOrDefault(x => x.No_Proyecto == NoProyecto);
            }


        }

        public void Guardarcambios(Proyecto_Residencia pro)
        {
            using (var context = new ResidenciasEntities(new AutomatizacionResidencias.Acciones.Conexion().returnconexion().ConnectionString))
            {
                var residencia = context.Proyecto_Residencia.FirstOrDefault(x => x.No_Proyecto ==pro.No_Proyecto);
                residencia.Nombre_Proyecto = pro.Nombre_Proyecto;
                residencia.Nombre_de_la_Empresa = pro.Nombre_de_la_Empresa;
                residencia.Nombre_Asesor_Externo = pro.Nombre_Asesor_Externo;
                residencia.Ultima_modificacion = DateTime.Now;
                residencia.Telefono_Asesor_Externo = pro.Telefono_Asesor_Externo;
                residencia.Cargo_Asesor_Externo = pro.Cargo_Asesor_Externo;
                residencia.Correo_Asesor_Externo = pro.Correo_Asesor_Externo;
                residencia.Telefono_Asesor_Externo = pro.Telefono_Asesor_Externo;
                context.SaveChanges();
            }
        }

        public override void Registrardatos(string datos, out string Errores)
        {
            throw new NotImplementedException();
        }
    }
}
