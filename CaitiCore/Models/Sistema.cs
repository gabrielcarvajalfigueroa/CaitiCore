using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public interface Sistema
    {
        public ProfesorModel _profesorEnSesion { get; set; }

        public Curso _cursoEnSesion { get; set; }

        List<ProfesorModel> GetProfesorModels();

        void InsertProfesorModel(ProfesorModel profesor);

        void InsertCurso(ProfesorModel profeEnSesion,Curso curso);

        Planificacion CrearPlanificacionDefault();

        void ActualizarPlanificacion(List<Semana> semanas);

    }
}
