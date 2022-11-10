using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Actividad
    {
        public List<ResultadoAprendizaje> Resultado_Aprendizaje { get; set; }

        public string Tipo_Actividad { get; set; }

        public string Unidad_Tematica { get; set; }

        public bool Is_Presencial { get; set; }

        public string Descripcion_Actividad { get; set; }

        public string Metodologia { get; set; }

        public string Producto { get; set; }

        public string Evaluacion { get; set; }

        public string Recursos_Aprendizaje { get; set; }

        public int H_Directas { get; set; }

        public int H_Indirectas { get; set; }

    }
}
