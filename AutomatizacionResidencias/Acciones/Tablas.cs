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
        public string color { get; set; }
        public string status { get; set; }
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


    public class TablaAsesor
    {

        public int IdAsesor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Turno { get; set; }

    }



    public class statusdeproyecto {
        public int IdStatus { get; set; }
        public string nombre { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
    }

    public class ComboGrupo {
        public int IdGrupo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class TablaHorario {
        public int? No_proyecto { get; set; }

        public int? IdPresentacion { get; set; }
        public int? IdGrupo { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Horainicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
    }
}
