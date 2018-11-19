using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatizacionResidencias
{
    public class Tablaproyecto
    {
        public int No_Proyecto { get; set; }
        public string Nombre_Proyecto { get; set; }
        public string Nombre_de_la_Empresa { get; set; }
        public string Nombre_Asesor_Externo { get; set; }
        public string Cargo_Asesor_Externo { get; set; }
        public string Telefono_Asesor_Externo { get; set; }
        public string Correo_Asesor_Externo { get; set; }
        public Nullable<System.DateTime> Fecha_Registro { get; set; }
        public Nullable<int> Asesorinterno { get; set; }
        public Nullable<int> Status { get; set; }
        public string Periodo { get; set; }
    }

    public class TablaAlumno {
        public int NoControl { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public Nullable<int> Semestre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Nullable<int> NoProyecto { get; set; }
    }

    public class statusdeproyecto {
        public int IdStatus { get; set; }
        public string nombre { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
    }
}
