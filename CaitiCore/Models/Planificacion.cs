using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Planificacion
    {
        public List<Semana> Semanas { get; set; }

        public Planificacion()
        {
            Semanas = new List<Semana>();
        }

    }
}
