using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Models
{
    public class Semana : ViewModelBase
    {
        public string Id_Semana { get; set; }

        public ObservableCollection<Clase> _clases;
        public ObservableCollection<Clase> Clases 
        {
            get
            {
                return _clases;
            }
            set
            {
                _clases = value;
                OnPropertyChanged(nameof(Clases));
            }
        }

        public Semana()
        {
            Clases = new ObservableCollection<Clase>();
        }
    }
}
