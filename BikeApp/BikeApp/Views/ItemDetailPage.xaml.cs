using BikeApp.Data.Routes;
using BikeApp.Data.Themes;
using BikeApp.ViewModels;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace BikeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        private async void ShowOnMapButton_Clicked(object sender, System.EventArgs e)
        {
            var itemId = ((ItemDetailViewModel)BindingContext).itemId;
            var item = Routes.AllRoutes.FirstOrDefault(r => r.Id == itemId);

            await Navigation.PushAsync(new MapPage(item));
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
    }
}