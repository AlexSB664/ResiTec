using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AutomatizacionResidencias
{
    public partial class ResidenciasEntities:DbContext
    {
        public ResidenciasEntities(String Conectionstring)
          : base(Conectionstring)
        {
        }
    }
}
