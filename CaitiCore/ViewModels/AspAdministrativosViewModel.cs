using CaitiCore.Commands;
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


        public ICommand Cerrar { get; }

        public AspAdministrativosViewModel(ModalNavigationService cerrar)
        {
            _aspAdministrativo = "Cátedra [70%]\n- 3 Pruebas P1, P2 y P3\n - 3 Pruebas Cortas PC1, PC2 y PC3\n - 3 Tareas T1, T2 y T3\n N1 = P1 * 0.7 + PC * 0.15 + T1 * 0.15\n N2 = P2 * 0.7 + PC * 0.15 + T2 * 0.15\n N3 = P3 * 0.7 + PC * 0.15 + T3 * 0.15\n NFC < Nota Final Cátedra> = N1 * 0.3 + N2 * 0.3 + N3 * 0.4\n Taller[30 %]\n - Ponderaciones de las entregas detalladas en el taller\n Nota Final Asigntura\n - Si(NFC y NFT) >= 4-- > NFA = NFC * 0,7 + NFT * 0,3\n - Si(NFT >= 4 y 3, 4 <= NFC <= 3, 9)-- > Rendir Examen Recuperativo\n - Si(NFT < 4 o NFC < 3, 4)-- > Reprobación del Ramo";
            Cerrar = new CloseModalCommand(cerrar);
        }
    }
}
