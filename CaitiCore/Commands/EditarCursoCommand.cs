using CaitiCore.Models;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class EditarCursoCommand : CommandBase
    {
        private readonly NavigationService _cursoViewNavigationService;
        private readonly Sistema _sistema;

        public EditarCursoCommand(Sistema sistema, NavigationService cursoViewNavigationService)
        {
            _sistema = sistema;
            _cursoViewNavigationService = cursoViewNavigationService;
        }

        public override void Execute(object parameter)
        {
            _sistema._cursoEnSesion = (Curso)parameter;
            Debug.WriteLine("hola");
            Debug.WriteLine(_sistema._cursoEnSesion.Nombre_Curso);
            _cursoViewNavigationService.Navigate();
        }
    }
}
