using Caliburn.Micro;
using System.Windows;

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

        #region Commands

        #region Drag Move Command Action
        /// <summary>
        /// allows to move the window when the style is none
        /// </summary>
        /// <param name="parameter">the indow itself here/param>
        public void DragMove(object parameter)
        {
            if (parameter is Window window)
            {
                window.DragMove();
            }
        }
        #endregion

        #region Close Application Command Action
        /// <summary>
        /// allows to close the window
        /// </summary>
        public void CloseWindow()
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region Collapse Application Command Action
        /// <summary>
        /// allows to collapse the window
        /// </summary>
        public void CollapseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.WindowState=WindowState.Minimized;
            }
        }
        #endregion




        #endregion
        public MainViewModel()
        {
        }



    }
}
