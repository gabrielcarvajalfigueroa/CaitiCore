using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Curso
    {
        public string Nombre_Curso { get; set; }

        public string Carrera { get; set; }

        public string Coordinador { get; set; }
        
        public string Unidad_Responsable { get; set; }

        public string Codigo_NRC { get; set; }

        public int Semestre_Ano { get; set; }

        public int Semestre_Malla { get; set; }

        public int Creditos_SCT { get; set; }

        public string Tipo { get; set; }

        public OrganizacionSemestral Organizacion { get; set; }

        public List<Ayudante> Ayudantes { get; set; }

        public string Proposito { get; set; }

        public List<ResultadoAprendizaje> RAs { get; set; }

        public Planificacion Planificacion_Curso { get; set; }

        public Curso(string nombre_Curso, string carrera, string coordinador, string codigo_NRC, Planificacion planificacion_Curso)
        {
            Nombre_Curso = nombre_Curso;
            Carrera = carrera;
            Coordinador = coordinador;
            Codigo_NRC = codigo_NRC;
            Planificacion_Curso = planificacion_Curso;
        }
    }
}
