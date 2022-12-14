using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Clase : Semana
    {
        public Clase()
        {

        }
        public Clase(string id_Clase)
        {
            Id_Clase = id_Clase;
            Actividades = new ObservableCollection<Actividad>();
        }

        public string Id_Clase { get; set; }

        public string Fecha_Planificada { get; set; }

        public string Fecha_Programada { get; set; }

        public bool Progreso { get; set; }

        public string Comentario { get; set; }

        public ObservableCollection<Actividad> Actividades { get; set; }
    }
}
