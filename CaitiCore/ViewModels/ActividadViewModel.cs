using CaitiCore.Commands;
using CaitiCore.Models;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaitiCore.ViewModels
{
    public class ActividadViewModel : ViewModelBase
    {
        private string _id_semana;

        public string Id_Semana
        {
            get
            {
                return _id_semana;
            }
            set
            {
                _id_semana = value;
                OnPropertyChanged(nameof(Id_Semana));
            }
        }
        private string _id_clase;

        public string Id_Clase
        {
            get
            {
                return _id_clase;
            }
            set
            {
                _id_clase = value;
                OnPropertyChanged(nameof(Id_Clase));
            }
        }

        private string _tipo;

        public string Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
                OnPropertyChanged(nameof(Tipo));
            }
        }
        public ICommand Guardar { get; }
        public ICommand Cerrar { get; }

        public ActividadViewModel(PlanificacionViewModel pvm, ModalNavigationService cerrar)
        {

            Guardar = new GuardarCommand(pvm, this);

            Cerrar = new CloseModalCommand(cerrar);
        }

        public class GuardarCommand : CommandBase
        {
            public PlanificacionViewModel PVM;
            ActividadViewModel ACTVM;

            public GuardarCommand(PlanificacionViewModel pVM, ActividadViewModel actVM)
            {

                PVM = pVM;
                ACTVM = actVM;
            }

            public override void Execute(object parameter)
            {
                int idS = int.Parse(ACTVM.Id_Semana) - 1;
                int idC = int.Parse(ACTVM.Id_Clase) - 1;
                PVM.ListaSemanas[idS].Clases[idC].Actividades.Add(new Actividad(ACTVM.Tipo));
            }
        }
    }
}
