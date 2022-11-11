using CaitiCore.Models;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class AgregarPropositoCommand : CommandBase
    {
        Sistema sistema;
        PropositoViewModel propositoViewModel;

        public AgregarPropositoCommand(Sistema sistema, PropositoViewModel propositoViewModel)
        {
            this.sistema = sistema;
            this.propositoViewModel = propositoViewModel;
        }

        public override void Execute(object parameter)
        {
            // Guarda en el registro
            sistema.InsertarProposito(propositoViewModel.Proposito, sistema._profesorEnSesion, sistema._cursoEnSesion);

            // Actualiza al curso en sesion
            sistema._cursoEnSesion.Proposito = propositoViewModel.Proposito;
        }
    }
}
