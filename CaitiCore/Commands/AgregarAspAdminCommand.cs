using CaitiCore.Models;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class AgregarAspAdminCommand : CommandBase
    {
        Sistema sistema;
        AspAdministrativosViewModel aspAdministrativosViewModel;

        public AgregarAspAdminCommand(Sistema sistema, AspAdministrativosViewModel aspAdministrativosViewModel)
        {
            this.sistema = sistema;
            this.aspAdministrativosViewModel = aspAdministrativosViewModel;
        }

        public override void Execute(object parameter)
        {
            // Guarda en el registro
            sistema.InsertarAspAdmin(aspAdministrativosViewModel.AspectoAdministrativo, sistema._profesorEnSesion, sistema._cursoEnSesion);

            // Actualiza al curso en sesion
            sistema._cursoEnSesion.Asp_Administrativo = aspAdministrativosViewModel.AspectoAdministrativo;
        }
    }
}
