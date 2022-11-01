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
                , new NavigationService(_navigationStore, CreateMenuViewModel)
                , new NavigationService(_navigationStore, CreateRegistroViewModel));
        }

        private RegistroViewModel CreateRegistroViewModel()
        {
            return new RegistroViewModel(_sistema,
                new NavigationService(_navigationStore, CreateMenuViewModel),
                new NavigationService(_navigationStore, CreateInicioViewModel));
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
                new ModalNavigationService(_modalnavigationStore, CreateResultadosAprendizajeViewModel));
        }

        // Inicio de los POPUPS
        private PropositoViewModel CreatePropositoViewModel()
        {
            return new PropositoViewModel(new ModalNavigationService(_modalnavigationStore,CreateCursoViewModel));// La segunda funcion no sirve de nada es Para que no quede en null el atributo de la clase o se cae
        }

        private ResultadosAprendizajeViewModel CreateResultadosAprendizajeViewModel()
        {
            return new ResultadosAprendizajeViewModel(new ModalNavigationService(_modalnavigationStore, CreateCursoViewModel));
        }

        // Fin de los POPUPS

        private PlanificacionViewModel CreatePlanificacionViewModel()
        {
            return new PlanificacionViewModel(_sistema,
                new NavigationService(_navigationStore,CreateCursoViewModel));
        }


    }
}
