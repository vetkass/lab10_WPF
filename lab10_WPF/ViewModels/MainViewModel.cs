using Caliburn.Micro;

namespace lab10_WPF.ViewModels
{
    public class MainViewModel:Screen
    {
        #region UserName
        /// <summary>
        /// User Name
        /// </summary>
        private string _UserName = "";
        public string UserName
        {
            get => _UserName;
            set { _UserName = value; NotifyOfPropertyChange(nameof(UserName));  }
        }
        #endregion

        #region Password
        /// <summary>
        /// Pasword
        /// </summary>
        private string _Password = "";
        public string Password
        {
            get => _Password;
            set { _Password = value; NotifyOfPropertyChange(nameof(Password)); }
        }
        #endregion

        public MainViewModel()
        {
        }



    }
}
