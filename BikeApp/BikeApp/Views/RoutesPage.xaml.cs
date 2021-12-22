using BikeApp.Data.Themes;
using BikeApp.Models;
using BikeApp.Services.Alert;
using BikeApp.ViewModels;
using BikeApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp.Views
{
    public partial class RoutesPage : ContentPage
    {
        RoutesViewModel _viewModel;

        public RoutesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new RoutesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            UpdateLayout();
            UpdateItems();
        }

        private void UpdateItems() => ((RoutesViewModel)BindingContext).ExecuteLoadItemsCommand();

        private void UpdateLayout()
        {
            ((ContentPage)FindByName("RoutesViewModel")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
        }
    }
}