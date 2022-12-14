using CaitiCore.Commands;
using CaitiCore.Models;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaitiCore.ViewModels
{
    public class RecursosViewModel : ViewModelBase
    {

        private string _contenidoVM;

        public string ContenidoVM
        {
            get
            {
                return _contenidoVM;
            }
            set
            {
                _contenidoVM = value;
                OnPropertyChanged(nameof(ContenidoVM));
            }
        }

        public ObservableCollection<Recurso> _recursos;


        public ObservableCollection<Recurso> Recursos
        {
            get
            {
                return _recursos;
            }

        }

        public ICommand Guardar { get; }

        public ICommand Cerrar { get; }

        public RecursosViewModel(Sistema sistema, ModalNavigationService cerrar)
        {
            _recursos = new ObservableCollection<Recurso>(sistema._cursoEnSesion.Recursos);

            Guardar = new AgregarRecursoCommand(this, sistema);
            Cerrar = new CloseModalCommand(cerrar);
        }

    }
}
