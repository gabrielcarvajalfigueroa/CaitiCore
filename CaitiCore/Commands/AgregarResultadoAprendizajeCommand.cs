using CaitiCore.Models;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class AgregarResultadoAprendizajeCommand : CommandBase
    {
        ResultadosAprendizajeViewModel RAVM;
        Sistema sistema;

        public AgregarResultadoAprendizajeCommand(ResultadosAprendizajeViewModel rAVM, Sistema sistema)
        {
            RAVM = rAVM;
            this.sistema = sistema;
        }

        public override void Execute(object parameter)
        {
            ResultadoAprendizaje ra = new ResultadoAprendizaje(RAVM.ContenidoVM);

            // Guarda en el sistema
            sistema.InsertarRA(ra, sistema._profesorEnSesion, sistema._cursoEnSesion);            

            // Guarda en la sesion
            sistema._cursoEnSesion.RAs.Add(ra);

            // Actualiza el datagrid
            RAVM.RAS.Add(ra);            
        }
    }
}
