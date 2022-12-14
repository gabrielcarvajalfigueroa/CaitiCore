using CaitiCore.Commands;
using CaitiCore.Models;
using CaitiCore.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaitiCore.ViewModels
{
    public class InicioViewModel : ViewModelBase
    {
        private string _rut;

        public string RUT
        {
            get
            {
                return _rut;
            }
            set
            {
                _rut = value;
                OnPropertyChanged(nameof(RUT));
            }
        }
        

        public ICommand ContinuarCommand { get; }

        public ICommand ActualizarDatosAPI { get; }

        public InicioViewModel(Sistema sistema, NavigationService menuNavigationService)
        {            
            ContinuarCommand = new IniciarSesionCommand(this, sistema, menuNavigationService);

            ActualizarDatosAPI = new ActualizarDatosAPICommand();
        }        
    }
}
