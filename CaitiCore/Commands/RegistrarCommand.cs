using CaitiCore.Models;
using CaitiCore.Services;
using CaitiCore.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaitiCore.Commands
{
    public class RegistrarProfesorCommand : CommandBase
    {
        private readonly RegistroViewModel _registroViewModel;
        private readonly Sistema _sistema;
        private readonly NavigationService _menuView;

        public RegistrarProfesorCommand(RegistroViewModel registroViewModel,
            Sistema sistema,
            NavigationService _menuViewNavigationService)
        {
            _registroViewModel = registroViewModel;
            _sistema = sistema;
            _menuView = _menuViewNavigationService;

        }

        public override void Execute(object parameter)
        {
            ProfesorModel profesor = new ProfesorModel(_registroViewModel.Nombre, _registroViewModel.Correo
                , _registroViewModel.Telefono, "Horas de oficina pendiente");

            profesor.Cursos = new List<Curso>(); // Es necasario para que se cree bien el JSON



            try
            {

                _sistema.InsertProfesorModel(profesor); // Inserta en el JSON

                _sistema._profesorEnSesion = profesor; // Actualiza el profesor a utilizar

                _menuView.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema al Insertar el Profesor", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
