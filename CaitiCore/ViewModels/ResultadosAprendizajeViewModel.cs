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
    public class ResultadosAprendizajeViewModel : ViewModelBase
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
        public ObservableCollection<ResultadoAprendizaje> _ras;


        public ObservableCollection<ResultadoAprendizaje> RAS
        {
            get
            {
                return _ras;
            }

        }


        public ICommand Guardar { get; }
        public ICommand Cerrar { get; }

        public ResultadosAprendizajeViewModel(Sistema sistema, ModalNavigationService cerrar)
        {
            
            _ras = new ObservableCollection<ResultadoAprendizaje>(sistema._cursoEnSesion.RAs);

            Guardar = new AgregarResultadoAprendizajeCommand(this, sistema);
            Cerrar = new CloseModalCommand(cerrar);
        }

    }
}
