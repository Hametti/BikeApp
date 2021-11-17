using BikeApp.ViewModels;
using BikeApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BikeApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        //Code that will be executed after clicking on item with "OnMenuItemClicked" attribute
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
