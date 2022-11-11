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
        public ObservableCollection<ResultadoAprendizaje> _ras;


        public ObservableCollection<ResultadoAprendizaje> RAS
        {
            get
            {
                return _ras;
            }

        }

        public ICommand Cerrar { get;  }

        public ResultadosAprendizajeViewModel(ModalNavigationService cerrar)
        {
            ResultadoAprendizaje[] resultados = { new ResultadoAprendizaje("1", "Comprender los conceptos asociados a los procesos de la Ingeniería de Software"), new ResultadoAprendizaje("2", "Seleccionar el modelo de proceso más adecuado para la aplicación a desarrollar") };


            List<ResultadoAprendizaje> resultadoAprendizajes = new List<ResultadoAprendizaje>(resultados);


            _ras = new ObservableCollection<ResultadoAprendizaje>(resultadoAprendizajes);

            Cerrar = new CloseModalCommand(cerrar);
        }

    }
}
