using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class ResultadoAprendizaje
    {
        public ResultadoAprendizaje(string id, string resultado)
        {
            Id = id;
            Resultado = resultado;
        }

        public string Id { get; set; }

        public string Resultado { get; set; }

    }
}
