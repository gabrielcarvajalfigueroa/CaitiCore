using CaitiCore.Models;
using CaitiCore.Services;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaitiCore.Commands
{
    public class IniciarSesionCommand : CommandBase
    {
        private readonly InicioViewModel _inicioViewModel;
        private readonly Sistema _sistema;
        private readonly NavigationService _menuViewNavigationService;

        private bool _existProfessor = false;

        public IniciarSesionCommand(InicioViewModel inicioViewModel,
            Sistema sistema,
            NavigationService menuViewNavigationService)
        {
            _inicioViewModel = inicioViewModel;
            _sistema = sistema;
            _menuViewNavigationService = menuViewNavigationService;
        }

        public override void Execute(object parameter)
        {

            List<Profesor> Profesores = _sistema.GetProfesorModels();

            foreach (var profesor in Profesores)
            {
                if(profesor.RUT == _inicioViewModel.RUT)
                {
                    _sistema._profesorEnSesion = profesor;

                    _menuViewNavigationService.Navigate();
                    _existProfessor = true;
                }
                
               
            }

            if (!_existProfessor)
            {

                Profesor profesorAPI = _sistema.BuscarProfesorAPI(_inicioViewModel.RUT);

                if(profesorAPI.RUT == "-1")
                {
                    MessageBox.Show("El profesor no se encuentra Registrado", "Registrar Usuario",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _sistema._profesorEnSesion = profesorAPI;

                    _menuViewNavigationService.Navigate();
                    _existProfessor = true;
                }
                
            }

        }
    }
}
