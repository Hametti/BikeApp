using BikeApp.Data.Routes;
using BikeApp.Data.Themes;
using BikeApp.Models;
using BikeApp.Services.Alert;
using BikeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BikeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            AddSampleRoute();
            InitializeComponent();
        }

        private void AddSampleRoute()
        {
            var route = new Route()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Sample description",
                Text = "Sample route",
                Seconds = 666,
                MapPath = new List<Position>
                {
                    new Position(49.58514665724434, 20.715647442036513),
                    new Position(49.582826187575115, 20.71954282098077),
                    new Position(49.582182751417896, 20.72559924868848),
                    new Position(49.582558380046976, 20.72669359000185),
                    new Position(49.58553906764385, 20.72585284675587),
                }
            };

            Routes.AllRoutes.Add(route);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            ((StackLayout)FindByName("Logo")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
            ((StackLayout)FindByName("Content")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor2);

            for (int i = 1; i <= 12; i++)
                ((Label)FindByName($"Label{i}")).TextColor = Color.FromHex(CurrentTheme.TextColor);

            //This is a sample way to connect view with viewModel, uncomment and use if necessary
            //((MainViewModel)BindingContext).DoSomething();
        }
    }
}