using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public interface Sistema
    {
        public Profesor _profesorEnSesion { get; set; }

        public Curso _cursoEnSesion { get; set; }

        List<Profesor> GetProfesorModels();                

        Planificacion CrearPlanificacionDefault();

        void ActualizarPlanificacion(List<Semana> semanas);

        void InsertarProposito(string Proposito, Profesor profesorEnSesion, Curso cursoEnSesion);

        void InsertarAspAdmin(string AspAdmin, Profesor profesorEnSesion, Curso cursoEnSesion);

    }
}
