using CaitiCore.Commands;
using CaitiCore.Models;
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

        public ICommand Guardar { get; }
        public ICommand Cerrar { get; }

        public PropositoViewModel(Sistema sistema, ModalNavigationService cerrar)
        {
            _proposito = sistema._cursoEnSesion.Proposito;            

            Guardar = new AgregarPropositoCommand(sistema, this);
            Cerrar = new CloseModalCommand(cerrar);
        }
        
    }
}
