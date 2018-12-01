using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatizacionResidencias.Acciones
{
    public class Periodos
    {
        public bool crearperiodo(AutomatizacionResidencias.Periodos periodo,out string Errores) {
            using ( var per = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                try
                {
                    per.Periodos.Add(periodo);
                    per.SaveChanges();
                    Errores = "";
                    return true;
                }
                catch(Exception ex) {
                    Errores = ex.Message;
                    return false;
                }
            }
        }



        public bool Establecerperiodo(string PeriodoId, out string Errores)
        {
            using (var per = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                try
                {
                   var pe= per.Params.FirstOrDefault(x=>x.Llave=="Periodoactual");
                    pe.Valor = PeriodoId;

                    per.SaveChanges();
                    Errores = "";
                    return true;
                }
                catch (Exception ex)
                {
                    Errores = ex.Message;
                    return false;
                }
            }
        }


        public AutomatizacionResidencias.Periodos periodoactual() {

            AutomatizacionResidencias.Periodos periodoactual = new AutomatizacionResidencias.Periodos();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                var cur = context.Params.FirstOrDefault(x=>x.Llave== "Periodoactual").Valor;
                int perio = int.Parse(cur);
                periodoactual = context.Periodos.FirstOrDefault(x=>x.Idperiodo==perio);
            }
            return periodoactual;

        }


        public List<AutomatizacionResidencias.Periodos> listaperiodos(out string Errores) {
            List<AutomatizacionResidencias.Periodos> pera = new List<AutomatizacionResidencias.Periodos>();
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
            {
                try
                {
                    pera = (from row in context.Periodos select row).ToList(); ;

                  
                   
                    Errores = "";
                    return pera;
                }
                catch (Exception ex)
                {
                    Errores = ex.Message;
                    return pera;
                }
            }
        }
    }
}
