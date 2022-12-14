using CaitiCore.Models;
using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class ModalNavigateCommand : CommandBase
    {        
        private readonly ModalNavigationService _modalnavigationService;
       
        public ModalNavigateCommand(ModalNavigationService modalnavigationService)
        {
            _modalnavigationService = modalnavigationService;
        }

        public override void Execute(object parameter)
        {
            if(parameter == null)
            {
                _modalnavigationService.Navigate();
            }
            else
            {
                Clase clase = (Clase)parameter;                
                _modalnavigationService.Navigate(clase.Id_Semana,clase.Id_Clase);
            }
            
        }
    }
}
