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
    public class MenuViewModel : ViewModelBase
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
        
        public ObservableCollection<Curso> _cursosProfeEnSesion;


        public ObservableCollection<Curso> CursosProfeEnSesion
        {
            get
            {
                return _cursosProfeEnSesion;
            }

        }

        private string _nombreCurso;

        public string NombreCurso
        {
            get
            {
                return _nombreCurso;
            }
            set
            {
                _nombreCurso = value;
                OnPropertyChanged(nameof(NombreCurso));
            }
        }

        private string _creditos;

        public string Creditos
        {
            get
            {
                return _creditos;
            }
            set
            {
                _creditos = value;
                OnPropertyChanged(nameof(Creditos));
            }
        }
        
        public ICommand EditarCurso { get; }

        public ICommand DescargarPDF { get; }
        

        public ICommand Volver { get; }

        public MenuViewModel(Sistema sistema,
                             NavigationService InicioView,
                             NavigationService CursoView)
                             
        {
            _nombreProfesor = sistema._profesorEnSesion.Nombre;

            _cursosProfeEnSesion = new ObservableCollection<Curso>(sistema._profesorEnSesion.Cursos);            

            EditarCurso = new EditarCursoCommand(sistema, CursoView);
            DescargarPDF = new DescargarPDFCommand();
            Volver = new NavigateCommand(InicioView);

        }
        
    }
}