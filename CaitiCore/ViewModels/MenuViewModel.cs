using CaitiCore.Commands;
using CaitiCore.Models;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        private Curso _selectedCurso;

        public Curso SelectedCurso
        {
            get
            {
                return _selectedCurso;
            }
            set
            {
                _selectedCurso = value;
                OnPropertyChanged(nameof(SelectedCurso));
                Debug.WriteLine(_selectedCurso.Nombre_Curso);
                Debug.WriteLine(_selectedCurso.Carrera);
            }
        }

        private Curso _dataContext;

        public Curso DataContext
        {
            get
            {
                Debug.WriteLine("HOLAAAAAAAAA");
                Debug.WriteLine(_dataContext);
                return _dataContext;
            }
            
        }

        public ICommand EditarCurso { get; }

        public ICommand DescargarPDF { get; }

        public ICommand Aceptar { get; }

        public ICommand Volver { get; }

        public MenuViewModel(Sistema sistema,
                             NavigationService InicioView,
                             NavigationService CursoView)
                             
        {
            _nombreProfesor = sistema._profesorEnSesion.Nombre;

            _cursosProfeEnSesion = new ObservableCollection<Curso>(sistema._profesorEnSesion.Cursos);

            Aceptar = new AgregarCursoCommand(this, sistema);

            EditarCurso = new EditarCursoCommand(sistema, CursoView);
            DescargarPDF = new DescargarPDFCommand();
            Volver = new NavigateCommand(InicioView);

        }
        /*
        public void AgregarCurso(Subject subject)
        {
            _subjectsProfeEnSesion.Append<Subject>(subject);
        }*/
    }
}