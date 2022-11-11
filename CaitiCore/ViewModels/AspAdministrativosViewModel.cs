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
    public class AspAdministrativosViewModel : ViewModelBase
    {
        private string _aspAdministrativo;

        public string AspectoAdministrativo
        {
            get
            {
                return _aspAdministrativo;
            }
            set
            {
                _aspAdministrativo = value;
                OnPropertyChanged(nameof(AspectoAdministrativo));
            }
        }


        public ICommand Guardar { get; }

        public ICommand Cerrar { get; }

        public AspAdministrativosViewModel(Sistema sistema, ModalNavigationService cerrar)
        {
            _aspAdministrativo = sistema._cursoEnSesion.Asp_Administrativo;            

            Guardar = new AgregarAspAdminCommand(sistema, this);
            Cerrar = new CloseModalCommand(cerrar);
        }
    }
}
