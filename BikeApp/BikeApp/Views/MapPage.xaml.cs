using Acr.UserDialogs;
using BikeApp.Data.Themes;
using BikeApp.Models;
using BikeApp.Sensors;
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
    public partial class MapPage : ContentPage
    {

        public MapPage(Route route)
        {
            InitializeComponent();

            ((Map)FindByName("map")).MapElements.Add(route.GetPolyline());
            ((Map)FindByName("map")).MoveToRegion(new MapSpan(route.MapPath.FirstOrDefault(), 0.01, 0.01));
            ((Map)FindByName("map")).IsShowingUser = true;
        }

        public MapPage()
        {
            InitializeComponent();
            ((Map)FindByName("map")).MoveToRegion(new MapSpan(Location.Position, 0.01, 0.01));
            ((Map)FindByName("map")).IsShowingUser = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            ((ContentPage)FindByName("Content")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
        }

        private void btnLoadLocation_Clicked(object sender, EventArgs e)
        {
            Location.UpdateLocation(this);

        }

        public void UpdateMap()
        {
            ((Map)FindByName("map")).MoveToRegion(new MapSpan(Location.Position, 0.01, 0.01));
        }

        public void AddRoute(Polyline polyline) => ((Map)FindByName("map")).MapElements.Add(polyline);
    }
}