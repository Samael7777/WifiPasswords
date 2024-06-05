using System.Windows;

namespace WifiPasswordsGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly AppModel _appModel;
        public App()
        {
            InitializeComponent();

            _appModel = new AppModel();
            var vm = new MainViewModel(_appModel);
            var window = new MainWindow()
            {
                DataContext = vm
            };
            Current.MainWindow = window;
            window.Show();
        }
        
        private void OnAppExit(object sender, ExitEventArgs e)
        {
            _appModel.Dispose();
        }
    }

}
