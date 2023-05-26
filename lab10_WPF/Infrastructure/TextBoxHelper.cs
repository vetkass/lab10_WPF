using System.Windows;

namespace lab10_WPF.Infrastructure
{
    public static class TextBoxHelper
    {
        public static readonly DependencyProperty WelcomeTextProperty =
        DependencyProperty.RegisterAttached("WelcomeText",
            typeof(string), typeof(TextBoxHelper),
            new PropertyMetadata(string.Empty));

        public static string GetWelcomeText(DependencyObject obj)
        {
            return (string)obj.GetValue(WelcomeTextProperty);
        }

        public static void SetWelcomeText(DependencyObject obj, string value)
        {
            obj.SetValue(WelcomeTextProperty, value);
        }
    }
}
