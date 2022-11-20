using CaitiCore.Commands;
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
        public ObservableCollection<string> _recursos;


        public ObservableCollection<string> Recursos
        {
            get
            {
                return _recursos;
            }

        }

        public ICommand Cerrar { get; }

        public RecursosViewModel(ModalNavigationService cerrar)
        {
            string[] recursos = { "Captura.de.Requerimientos.Diagramas.de.Actividades.pptx (2020-05-08)", "https://bestbipractices.wordpress.com/2013/07/10/breve-resumen-sobre-scrum/ (2020-05-18) "};


            List<string> Recursos = new List<string>(recursos);


            _recursos = new ObservableCollection<string>(Recursos);


            Cerrar = new CloseModalCommand(cerrar);
        }

    }
}
