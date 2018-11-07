using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionResidencias
{
    public interface Subject
    {

        void RegisterObserver();
        void RemoveObserver();
        void NotifyObserver();
    }
}
