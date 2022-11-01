using CaitiCore.Models;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class AgregarCursoCommand : CommandBase
    {
        MenuViewModel _menuViewModel;
        Sistema _sistema;

        public AgregarCursoCommand(MenuViewModel menuViewModel, Sistema sistema)
        {
            _menuViewModel = menuViewModel;
            _sistema = sistema;
        }

        public override void Execute(object parameter)
        {
            Curso curso = new Curso(_menuViewModel.NombreCurso, "Carrera1", "Coordinador1", "Codigo1", _sistema.CrearPlanificacionDefault());

            _sistema.InsertCurso(_sistema._profesorEnSesion, curso);

            _menuViewModel.CursosProfeEnSesion.Add(curso);
        }
    }
}
