using CaitiCore.Models;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class GuardarPlanificacionCommand : CommandBase
    {
        private readonly PlanificacionViewModel planificacionViewModel;
        private readonly Sistema sistema;

        public GuardarPlanificacionCommand(PlanificacionViewModel planificacionViewModel, Sistema sistema)
        {
            this.planificacionViewModel = planificacionViewModel;
            this.sistema = sistema;
        }

        public override void Execute(object parameter)
        {

            List<Semana> semanas = planificacionViewModel._listaSemanas.ToList();

            // Actualiza el json
            sistema.ActualizarPlanificacion(semanas);

            // Actualiza la app
            sistema._cursoEnSesion.Planificacion_Curso.Semanas = semanas;
        }
    }
}
