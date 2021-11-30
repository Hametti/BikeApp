using BikeApp.Data.Themes;
using BikeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetLayout();
        }

        private void SetLayout()
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