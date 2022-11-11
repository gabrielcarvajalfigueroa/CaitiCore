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
    public class AyudanteViewModel : ViewModelBase
    {
        private string _nombre;

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        private string _apellido;

        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
                OnPropertyChanged(nameof(Apellido));
            }
        }

        private string _correo;

        public string Correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;
                OnPropertyChanged(nameof(Correo));
            }
        }

        private string _telefono;

        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        private string _horarioAtencion;

        public string Horario_Atencion
        {
            get
            {
                return _horarioAtencion;
            }
            set
            {
                _horarioAtencion = value;
                OnPropertyChanged(nameof(Horario_Atencion));
            }
        }

        public ObservableCollection<Ayudante> _ayudantes;


        public ObservableCollection<Ayudante> Ayudantes
        {
            get
            {
                return _ayudantes;
            }

        }

        public ICommand Guardar { get; }

        public ICommand Cerrar { get; }

        public AyudanteViewModel(Sistema sistema, ModalNavigationService cerrar)
        {
            _ayudantes = new ObservableCollection<Ayudante>(sistema._cursoEnSesion.Ayudantes);

            Guardar = new AgregarAyudanteCommand(this, sistema);
            Cerrar = new CloseModalCommand(cerrar);
        }
    }
}
