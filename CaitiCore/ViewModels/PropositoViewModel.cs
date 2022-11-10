using CaitiCore.Commands;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaitiCore.ViewModels
{
    public class PropositoViewModel : ViewModelBase
    {
        private string _proposito;

        public string Proposito
        {
            get
            {
                return _proposito;
            }
            set
            {
                _proposito = value;
                OnPropertyChanged(nameof(Proposito));
            }
        }


        public ICommand Cerrar { get; }

        public PropositoViewModel(ModalNavigationService cerrar)
        {
            _proposito = "Al final del curso el alumno podrá realizar el análisis, diseño orientado a objetos y construcción de un producto de software de calidad, que satisfaga los requisitos, necesidades y restricciones solicitadas, en base a un proceso iterativo e incremental.\n\nEn este análisis y diseño utilizará el lenguaje de modelado UML, y será capaz de aplicar las buenas prácticas recomendadas.\n \nEl trabajo lorealizará con apoyo de herramientas de software.";

            Cerrar = new CloseModalCommand(cerrar);
        }
        
    }
}
