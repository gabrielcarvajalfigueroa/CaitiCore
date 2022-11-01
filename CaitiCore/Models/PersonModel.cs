using CaitiCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaitiCore.Model
{
    public class PersonModel : NotifyPropertyChangedHandler
    {
        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; NotifyPropertyChanged("FirstName"); }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; NotifyPropertyChanged("LastName"); }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; NotifyPropertyChanged("Gender"); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged("Age"); }
        }

        private double number;

        public double Number
        {
            get { return number; }
            set { number = value; NotifyPropertyChanged("Number"); }
        }

        public List<PersonModel> Items { get; set; }
    }
}
