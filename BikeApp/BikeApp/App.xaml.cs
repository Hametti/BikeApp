using BikeApp.Data.Helpers;
using BikeApp.Services;
using Xamarin.Forms;

namespace BikeApp
{
    public partial class App : Application
    {

        public App()
        {
            Initializer.LoadTheme();
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
