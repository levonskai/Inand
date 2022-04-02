using Inand.Theming;
using System.Windows;

namespace Inand.Demo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SetLight_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.SetTheme(BaseTheme.Light);
        }

        private void SetDark_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.SetTheme(BaseTheme.Dark);
        }
    }
}
