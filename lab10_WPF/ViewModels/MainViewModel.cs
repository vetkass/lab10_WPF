using Caliburn.Micro;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace lab10_WPF.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly IWindowManager _windowManager;

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

        #region Commands

         #region Sign In Command Action
        /// <summary>
        /// allows to open form window
        /// </summary>
        public void SignIn()
        {
            var window = Application.Current.MainWindow as Window;
            if (window != null)
            {
                window.Close();
            }
            ShellViewModel model = new ShellViewModel();
            _windowManager.ShowWindowAsync(model);
        }
        #endregion

        #endregion
        public MainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }
    }
}
