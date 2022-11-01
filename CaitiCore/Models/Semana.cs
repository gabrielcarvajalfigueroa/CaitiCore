using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Semana
    {
        public string Id_Semana { get; set; }

        public List<Clase> Clases { get; set; }

        public Semana()
        {
            Clases = new List<Clase>();
        }
    }
}
