using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionResidencias
{
    public interface Subject
    {

        void RegisterObserver(out string Errores);
        void RemoveObserver(out string Errores);
        void NotifyObserver(out string Errores);
    }
}
