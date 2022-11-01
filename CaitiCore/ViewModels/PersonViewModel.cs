using CaitiCore.ICommandUpdater;
using CaitiCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaitiCore.ViewModel
{
    public class PersonViewModel : NotifyPropertyChangedHandler
    {
        private ICommand _ShowDataCommand;

        private ICommand _AddCommand;

        private PersonModel _SelectedPersonModel;

        public PersonModel SelectedPersonModel

        {

            get { return _SelectedPersonModel; }

            set { _SelectedPersonModel = value; NotifyPropertyChanged("SelectedPersonModel"); }

        }


        private List<PersonModel> _Items;

        public List<PersonModel> Items

        {

            get { return _Items; }

            set { _Items = value; NotifyPropertyChanged("Items"); }

        }







        public PersonViewModel()

        {

            SelectedPersonModel = new PersonModel();
           
            

        }

        /// <summary>

        /// Show Json File to Grid via List

        /// </summary>

        public ICommand ShowDataCommand

        {

            get

            {

                if (_ShowDataCommand == null)

                {

                    _ShowDataCommand = new RelayCommand(param => this.GetJsonData(), null);

                }

                return _ShowDataCommand;

            }

        }

        private void GetJsonData()

        {

            string json = System.IO.File.ReadAllText(@"PeopleData.json");

            Items = JsonConvert.DeserializeObject<List<PersonModel>>(json);

            

        }

        //-----------

        public ICommand AddCommand

        {

            get

            {

                if (_AddCommand == null)

                {

                    _AddCommand = new RelayCommand(param => this.AddJsonData(), null);

                }

                return _AddCommand;

            }

        }

        private void AddJsonData()

        {

            Items.Add(SelectedPersonModel);

            var NewJsonData = JsonConvert.SerializeObject(Items, Formatting.Indented);

            File.WriteAllText(@"PeopleData.json", NewJsonData);

        }

    }
}
