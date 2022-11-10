using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Clase
    {
        public string Id_Clase { get; set; }

        public string Fecha_Planificada { get; set; }

        public string Fecha_Programada { get; set; }

        public bool Progreso { get; set; }

        public string Comentario { get; set; }

        public List<Actividad> Actividades { get; set; }
    }
}
