using CaitiCore.Models;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class AgregarAyudanteCommand : CommandBase
    {
        AyudanteViewModel ayudVM;
        Sistema sistema;

        public AgregarAyudanteCommand(AyudanteViewModel ayudanteViewModel, Sistema sistema)
        {
            this.ayudVM = ayudanteViewModel;
            this.sistema = sistema;
        }

        public override void Execute(object parameter)
        {
            Ayudante ayudante = new Ayudante(ayudVM.Nombre, ayudVM.Correo, ayudVM.Telefono, ayudVM.Horario_Atencion);

            // sistemainsertarayudante
            
            ayudVM.Ayudantes.Add(ayudante);
            
        }
    }
}
