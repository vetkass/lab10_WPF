using System;
using System.Text.RegularExpressions;

namespace lab10_WPF.Model
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public PassportModel Passport { get; set; }
        
    }


    public class PassportModel
    {
        #region Seria
        private short _Seria;
        public string Seria
        {
            get => _Seria.ToString("D4");
            set
            {
                Regex regex = new Regex(@"^[0-9][0-9][0-9][0-9]$");
                if (!regex.IsMatch(value)) throw new ArgumentException("Passport seria is between 0000 and 9999");
                _Seria = short.Parse(value);
            }
        }
        #endregion


        #region Number
        private int _Number;
        public string Number
        {
            get => _Number.ToString("D6");
            set
            {
                Regex regex = new Regex(@"^[0-9][0-9][0-9][0-9][0-9][0-9]$");
                if (!regex.IsMatch(value)) throw new ArgumentException("Passport number is between 000000 and 999999");
                _Number = int.Parse(value);
            }
    }
        #endregion

        public override string ToString()
        {
            return $"{Seria} №{Number}";
        }

    }


}
