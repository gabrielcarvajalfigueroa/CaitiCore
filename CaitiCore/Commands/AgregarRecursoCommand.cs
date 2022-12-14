using CaitiCore.Models;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class AgregarRecursoCommand : CommandBase
    {
        RecursosViewModel recursosViewModel;
        Sistema sistema;

        public AgregarRecursoCommand(RecursosViewModel recursosViewModel, Sistema sistema)
        {
            this.recursosViewModel = recursosViewModel;
            this.sistema = sistema;
        }

        public override void Execute(object parameter)
        {
            Recurso recurso = new Recurso(recursosViewModel.ContenidoVM);            

            // Guarda en el sistema
            sistema.InsertarRecurso(recurso, sistema._profesorEnSesion, sistema._cursoEnSesion);            

            // Guarda en la sesion
            sistema._cursoEnSesion.Recursos.Add(recurso);

            // Actualiza el datagrid
            recursosViewModel.Recursos.Add(recurso);
        }
    }
}
