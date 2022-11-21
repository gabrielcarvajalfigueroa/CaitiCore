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
            set
            {
                _listaSemanas = value;
                OnPropertyChanged(nameof(ListaSemanas));
            }
        }

        public ICommand Guardar { get; }

        public ICommand Volver { get; }

        public ICommand AgregarSemana { get; }

        public ICommand AgregarClase { get; }

        public ICommand AgregarActividad { get; }

        public PlanificacionViewModel(Sistema sistema,
                                      NavigationService CursoView,
                                      ModalNavigationService ActividadView)
        {
            _listaSemanas = new ObservableCollection<Semana>(sistema._cursoEnSesion.Planificacion_Curso.Semanas);

            //_listaSemanas[0].Clases[1].Actividades.Add(new Actividad("Catedra"));
                       


            AgregarActividad = new ModalNavigateCommand(ActividadView);
            AgregarSemana = new AgregarSemanaCommand(this);
            AgregarClase = new AgregarClaseCommand(this);

            //AgregarActividad = new AgregarActividadCommand(ActividadView, this);
            Guardar = new GuardarPlanificacionCommand(this, sistema);
            Volver = new NavigateCommand(CursoView);
        }

        public class AgregarSemanaCommand : CommandBase
        {
            PlanificacionViewModel PVM;

            public AgregarSemanaCommand(PlanificacionViewModel pVM)
            {
                PVM = pVM;
            }

            public override void Execute(object parameter)
            {
                Semana semana = new Semana();
                int numero = PVM.ListaSemanas.Count + 1;
                semana.Id_Semana = numero.ToString();

                Clase clase = new Clase("1");
                clase.Id_Semana = semana.Id_Semana;
                semana.Clases.Add(clase); // TODO: Falta q se cree bien
                PVM.ListaSemanas.Add(semana);
            }
        }

        public class AgregarClaseCommand : CommandBase
        {
            PlanificacionViewModel PVM;

            public AgregarClaseCommand(PlanificacionViewModel pVM)
            {
                PVM = pVM;
            }

            public override void Execute(object parameter)
            {
                Semana semana = (Semana)parameter;
                int indice = int.Parse(semana.Id_Semana) - 1;
                
                string id_clase = (PVM._listaSemanas[indice].Clases.Count + 1).ToString();
                Clase clase = new Clase(id_clase);
                clase.Id_Semana = semana.Id_Semana;
                PVM._listaSemanas[indice].Clases.Add(clase);
               

            }
        }

    }
}
