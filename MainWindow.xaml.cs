using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Diagnostics;

namespace cha_fivem
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void BtnLimpar_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Limpar button clicked!");

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}