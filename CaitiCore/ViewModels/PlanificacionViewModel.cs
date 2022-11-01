using CaitiCore.Commands;
using CaitiCore.Models;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaitiCore.ViewModels
{
    public class PlanificacionViewModel : ViewModelBase
    {
        public ObservableCollection<Semana> _listaSemanas;


        public ObservableCollection<Semana> ListaSemanas
        {
            get
            {
                return _listaSemanas;
            }

        }

        public ICommand Guardar { get; }

        public ICommand Volver { get; }

        public PlanificacionViewModel(Sistema sistema, NavigationService CursoView)
        {
            _listaSemanas = new ObservableCollection<Semana>(sistema._cursoEnSesion.Planificacion_Curso.Semanas);


            Guardar = new GuardarPlanificacionCommand(this, sistema);
            Volver = new NavigateCommand(CursoView);
        }

    }
}
