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
    public class InicioViewModel : ViewModelBase
    {
        private string _nombreUsuario;

        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
                OnPropertyChanged(nameof(NombreUsuario));
            }
        }
        

        public ICommand ContinuarCommand { get; }

        public InicioViewModel(Sistema sistema, NavigationService menuNavigationService)
        {            
            ContinuarCommand = new IniciarSesionCommand(this, sistema, menuNavigationService);
        }

    }
}
