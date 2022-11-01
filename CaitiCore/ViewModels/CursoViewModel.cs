using CaitiCore.Commands;
using CaitiCore.Models;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaitiCore.ViewModels
{
    public class CursoViewModel : ViewModelBase
    {
        private string _nombreProfesor; // Nombre del profesor que esta en sesion

        public string NombreProfesor
        {
            get
            {
                return _nombreProfesor;
            }
            set
            {
                _nombreProfesor = value;
                OnPropertyChanged(nameof(NombreProfesor));
            }
        }

        private string _cursoEditando; // Nombre del profesor que esta en sesion

        public string CursoEditando
        {
            get
            {
                return _cursoEditando;
            }
            set
            {
                _cursoEditando = value;
                OnPropertyChanged(nameof(CursoEditando));
            }
        }

        public ICommand Planificar { get; }

        public ICommand Proposito { get; }
        
        public ICommand RA { get; }
        public ICommand Volver { get; }

        public CursoViewModel(Sistema sistema,
                              NavigationService MenuView,
                              NavigationService PlanificacionView,
                              ModalNavigationService PropositoView,
                              ModalNavigationService RAView)
        {
            _nombreProfesor = sistema._profesorEnSesion.Nombre;
            _cursoEditando = sistema._cursoEnSesion.Nombre_Curso;

            Planificar = new NavigateCommand(PlanificacionView);

            Proposito = new ModalNavigateCommand(PropositoView);
            RA = new ModalNavigateCommand(RAView);
            Volver = new NavigateCommand(MenuView);
        }
    }
}