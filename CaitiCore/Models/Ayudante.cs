using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Ayudante
    {
        public Ayudante(string nombre, string correo, string telefono, string horario_Atencion)
        {
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Horario_Atencion = horario_Atencion;
        }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Horario_Atencion { get; set; }
    }
}
