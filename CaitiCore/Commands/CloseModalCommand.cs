using CaitiCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Commands
{
    public class CloseModalCommand : CommandBase
    {
        private readonly ModalNavigationService modalNavigationService;

        public CloseModalCommand(ModalNavigationService modalNavigationService)
        {
            this.modalNavigationService = modalNavigationService;
        }

        public override void Execute(object parameter)
        {
            modalNavigationService.CloseModalNavigationService();
        }
    }
}
