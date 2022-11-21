﻿using CaitiCore.Stores;
using CaitiCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Services
{
    public class ModalNavigationService
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public ModalNavigationService(ModalNavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void CloseModalNavigationService()
        {
            _navigationStore.Close();
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }

        public void Navigate(string id_semana,string id_clase)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
            ((ActividadViewModel)_navigationStore.CurrentViewModel).Id_Semana = id_semana;
            ((ActividadViewModel)_navigationStore.CurrentViewModel).Id_Clase = id_clase;
        }
    }
}
