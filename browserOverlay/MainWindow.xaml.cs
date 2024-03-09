using CefSharp;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace browserOverlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            var appSettings = config.Get<AppSettings>();

            if (appSettings == null)
            {
                this.Close();
                return;
            }

            this.Browser.Load(appSettings.url);

            int width = 0;
            int height = 0;

            if (appSettings.width == null)
            {
                MessageBox.Show("appsettings width must not be null", "browserOverlay", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            try
            {
                if (appSettings.width.EndsWith('%'))
                {
                    var relativeWidth = int.Parse(appSettings.width.Substring(0, appSettings.width.Length - 1));
                    width = (int)((double) relativeWidth / 100 * ((int)SystemParameters.PrimaryScreenWidth));
                }
                else
                {
                    width = int.Parse(appSettings.width);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("width must be in format \"345\" (in pixels) or \"50%\" (for relative)", "browserOverlay", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            if (appSettings.height == null)
            {
                MessageBox.Show("height must not be null", "browserOverlay", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            try
            {
                if (appSettings.height.EndsWith('%'))
                {
                    var relativeHeight = int.Parse(appSettings.height.Substring(0, appSettings.height.Length - 1));
                    height = (int)((double)relativeHeight / 100 * ((int)SystemParameters.PrimaryScreenHeight));
                }
                else
                {
                    height = int.Parse(appSettings.height);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("height must be in format \"345\" (in pixels) or \"50%\" (for relative)", "browserOverlay", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }


            this.Width = width;
            this.Height = height;

            if (appSettings.dockTop.GetValueOrDefault(false))
            {
                this.Top = 0;
            }

            if (appSettings.dockBottom.GetValueOrDefault(false))
            {
                this.Top = SystemParameters.PrimaryScreenHeight - height;
            }

            if (appSettings.dockLeft.GetValueOrDefault(false))
            {
                this.Left = 0;
            }

            if (appSettings.dockRight.GetValueOrDefault(false))
            {
                this.Left = SystemParameters.PrimaryScreenWidth - width;
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}