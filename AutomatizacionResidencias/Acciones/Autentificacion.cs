using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionResidencias.Acciones
{
    public class Autentificacion
    {
        public bool autentificar(string usuario,string password, out string Errores) {
            Errores = "";
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                if (context.Usuario.Any(x => x.Usuario1 == usuario && x.Password == password && x.Rol == "administrador"))
                {
                    return true;
                }
                else {
                    return false;
                }
            }
        }


        public bool autentificaralumno(string usuario, string password, out string Errores)
        {
            Errores = "";
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                if (context.Usuario.Any(x => x.Usuario1 == usuario && x.Password == password && x.Rol == "alumno"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
