using Caliburn.Micro;
using System.Windows;

namespace lab10_WPF.ViewModels
{
    public class BaseViewModel : Screen
    {
        #region Commands

        #region Drag Move Command Action
        /// <summary>
        /// allows to move the window when the style is none
        /// </summary>
        /// <param name="parameter">the window itself here/param>
        public void DragMove()
        {
            var window = Application.Current.MainWindow as Window;
            if (window != null)
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
        ///
        public void CollapseWindow()
        {
            var window = Application.Current.MainWindow as Window;
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }
        #endregion

        #endregion

        public BaseViewModel()
        {
        }
    }
}
