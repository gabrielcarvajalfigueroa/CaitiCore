using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Recurso 
    {
        public Recurso(string contenido)
        {
            Contenido = contenido;
        }

        public string Contenido { get; set; }
    }
}
