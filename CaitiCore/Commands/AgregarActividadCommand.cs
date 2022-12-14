using CaitiCore.Models;
using CaitiCore.Services;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class AgregarActividadCommand : CommandBase
    {
        private readonly ModalNavigationService _actividadView;
        private readonly PlanificacionViewModel PVM;       

        public AgregarActividadCommand(ModalNavigationService actividadView, PlanificacionViewModel pVM)
        {
            _actividadView = actividadView;
            PVM = pVM;
        }

        public override void Execute(object parameter)
        {
            Clase clase = (Clase)parameter;

            Semana semana = PVM._listaSemanas[0];
            

            Debug.WriteLine(PVM.ListaSemanas[0].Id_Semana);
            semana.Id_Semana = "hola";
            //PVM._listaSemanas[0].Id_Semana = "sdd"; //.Clases[0].Actividades.Add(new Actividad("xdddddddddd"));            
            PVM._listaSemanas[0] = semana;
            PVM._listaSemanas[2].Clases[0].Actividades = new ObservableCollection<Actividad>();
            PVM._listaSemanas[2].Clases[0].Actividades.Add(new Actividad("sxsd"));
            //PVM._listaSemanas[1] = semana;
            Debug.WriteLine(PVM.ListaSemanas[0].Id_Semana);
            //PVM._listaSemanas.Add(new Semana());
            /*
            foreach (Semana semana1 in PVM.ListaSemanas)
            {
                if(semana1.Id_Semana == semana)
                {
                    foreach(Clase clase1 in semana1.Clases)
                    {
                        if(clase1.Id_Clase == clase.Id_Clase)
                        {
                            clase1.Actividades.Add(new Actividad("TEsTEOOOOOOOOOO"));
                        }
                    }
                }
            }*/
            
        }
    }
}
