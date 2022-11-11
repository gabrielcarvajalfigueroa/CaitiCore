using CaitiCore.Models;
using CaitiCore.Services;
using CaitiCore.Stores;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CaitiCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Sistema _sistema;
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalnavigationStore;

        public App()
        {

            _sistema = new SistemaImpl();

            _navigationStore = new NavigationStore();

            _modalnavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
           


            _navigationStore.CurrentViewModel = CreateInicioViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalnavigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }


        private InicioViewModel CreateInicioViewModel()
        {
            return new InicioViewModel(_sistema
                , new NavigationService(_navigationStore, CreateMenuViewModel));
        }
        

        private MenuViewModel CreateMenuViewModel()
        {
            return new MenuViewModel(_sistema,
                new NavigationService(_navigationStore, CreateInicioViewModel),
                new NavigationService(_navigationStore,CreateCursoViewModel));
        }

        private CursoViewModel CreateCursoViewModel()
        {
            return new CursoViewModel(_sistema, 
                new NavigationService(_navigationStore, CreateMenuViewModel),
                new NavigationService(_navigationStore, CreatePlanificacionViewModel),
                new ModalNavigationService(_modalnavigationStore, CreatePropositoViewModel),
                new ModalNavigationService(_modalnavigationStore, CreateResultadosAprendizajeViewModel),
                new ModalNavigationService(_modalnavigationStore, CreateAyudanteViewModel),
                new ModalNavigationService(_modalnavigationStore, CreateAspAdministrativosViewModel),
                new ModalNavigationService(_modalnavigationStore, CreateRecursosViewModel));
        }

        // Inicio de los POPUPS
        private PropositoViewModel CreatePropositoViewModel()
        {
            return new PropositoViewModel(_sistema, new ModalNavigationService(_modalnavigationStore,CreateCursoViewModel));// La segunda funcion no sirve de nada es Para que no quede en null el atributo de la clase o se cae
        }

        private ResultadosAprendizajeViewModel CreateResultadosAprendizajeViewModel()
        {
            return new ResultadosAprendizajeViewModel(new ModalNavigationService(_modalnavigationStore, CreateCursoViewModel));
        }

        private AyudanteViewModel CreateAyudanteViewModel()
        {
            return new AyudanteViewModel(_sistema, new ModalNavigationService(_modalnavigationStore, CreateCursoViewModel));
        }

        private AspAdministrativosViewModel CreateAspAdministrativosViewModel()
        {
            return new AspAdministrativosViewModel(_sistema, new ModalNavigationService(_modalnavigationStore, CreateCursoViewModel));
        }

        private RecursosViewModel CreateRecursosViewModel()
        {
            return new RecursosViewModel(new ModalNavigationService(_modalnavigationStore, CreateCursoViewModel));
        }

        // Fin de los POPUPS

        private PlanificacionViewModel CreatePlanificacionViewModel()
        {
            return new PlanificacionViewModel(_sistema,
                new NavigationService(_navigationStore,CreateCursoViewModel),
                new ModalNavigationService(_modalnavigationStore,CreateActividadViewModel));
        }

        private ActividadViewModel CreateActividadViewModel()
        {
            return new ActividadViewModel(new ModalNavigationService(_modalnavigationStore, CreateCursoViewModel));
        }


    }
}
