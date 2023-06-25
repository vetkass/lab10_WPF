using Caliburn.Micro;
using lab10_WPF.Model;
using System.Linq;

namespace lab10_WPF.ViewModels
{
    public class ShellViewModel:  BaseViewModel
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

        private BindableCollection<PersonModel> _Persons;

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
            var persons = Enumerable.Range(1, 9).Select(i => new PersonModel
            {
                FirstName = "f"+i,
                LastName = "L"+i,
                MiddleName = "M"+i,
                PhoneNumber = "ph"+i,
                Passport = new PassportModel { Seria = "000"+i, Number = "00000"+i }
            });
            _Persons = new BindableCollection<PersonModel>(persons);            
        }



    }
}
