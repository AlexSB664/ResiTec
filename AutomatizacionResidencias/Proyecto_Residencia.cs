//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutomatizacionResidencias
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proyecto_Residencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyecto_Residencia()
        {
            this.Alumno = new HashSet<Alumno>();
            this.BitacoraTransacciones = new HashSet<BitacoraTransacciones>();
            this.HorarioPresentacion = new HashSet<HorarioPresentacion>();
        }
    
        public int No_Proyecto { get; set; }
        public string Nombre_Proyecto { get; set; }
        public string Nombre_de_la_Empresa { get; set; }
        public string Nombre_Asesor_Externo { get; set; }
        public string Cargo_Asesor_Externo { get; set; }
        public string Telefono_Asesor_Externo { get; set; }
        public string Correo_Asesor_Externo { get; set; }
        public Nullable<System.DateTime> Fecha_Registro { get; set; }
        public Nullable<int> IdAsesorInterno { get; set; }
        public Nullable<int> IdStatus { get; set; }
        public string Periodo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual Asesor_Interno Asesor_Interno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BitacoraTransacciones> BitacoraTransacciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioPresentacion> HorarioPresentacion { get; set; }
        public virtual Status Status { get; set; }
    }
}
