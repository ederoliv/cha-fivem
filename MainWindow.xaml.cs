using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace cha_fivem
{
    public partial class MainWindow : Window
    {
        private const string CachePath = @"C:\Users\%USERNAME%\AppData\Local\FiveM\FiveM.app\data";

        public MainWindow() => InitializeComponent();

        #region UI Methods
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            if (CleanFiles())
                MessageBox.Show("Limpeza realizada com sucesso!!");
            else
                MessageBox.Show("Houve algum erro ao tentar limpar os arquivos.");
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
        #endregion

        #region Deletion Methods

        private bool CleanFiles()
        {
            try
            {
                Delete_Cache();
                Delete_NuiStorage();
                Delete_ServerCache();
                Delete_ServerCachePriv();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool Delete_Cache()
        {
            try
            {
                Directory.Delete(Path.Combine(CachePath, "cache"), true);
                return true;
            }
            catch
            {
                return false;       
            }
        }

        private bool Delete_NuiStorage()
        {
            try
            {
                Directory.Delete(Path.Combine(CachePath, "nui-storage"), true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool Delete_ServerCache()
        {
            try
            {
                Directory.Delete(Path.Combine(CachePath, "server-cache"), true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool Delete_ServerCachePriv()
        {
            try
            {
                Directory.Delete(Path.Combine(CachePath, "server-cache-priv"), true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}