using Caliburn.Micro;
using lab10_WPF.Model;

namespace lab10_WPF.ViewModels
{
    public class ShellViewModel:Screen
    {
        #region Test Caliburn
        /// <summary>
        /// Test Caliburn
        /// </summary>
        private string _Test = "lab10 WPF";
        public string Test
        {
            get => _Test;
            set { _Test = value; NotifyOfPropertyChange(nameof(Test));  }
        }
        #endregion

        private BindableCollection<PersonModel> _Persons = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> Persons
        {
            get => _Persons;
            set
            {
                _Persons = value;
                NotifyOfPropertyChange(nameof(Persons));
            }
        }

        private PersonModel _selectedPerson;
        public PersonModel SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(nameof(SelectedPerson));
            }
        }

        public ShellViewModel()
        {
            _Persons.Clear();
            _Persons.Add(new PersonModel
            {
                FirstName = "f1",
                LastName = "L1",
                MiddleName = "M1",
                PhoneNumber = "ph1",
                Passport = new PassportModel { Seria = "0001", Number = "000001" }
                });
            _Persons.Add(new PersonModel
            {
                FirstName = "f2",
                LastName = "L2",
                MiddleName = "M2",
                PhoneNumber = "ph2",
                Passport = new PassportModel { Seria = "0001", Number = "000002" }
            });
            _Persons.Add(new PersonModel
            {
                FirstName = "f3",
                LastName = "L3",
                MiddleName = "M3",
                PhoneNumber = "ph3",
                Passport = new PassportModel { Seria = "0001", Number = "000003" }
            });
        }



    }
}
