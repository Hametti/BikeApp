using BikeApp.Data.Themes;
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
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            ((ContentPage)FindByName("Content")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
            ((Label)FindByName("Label1")).TextColor = Color.FromHex(CurrentTheme.TextColor);
        }
    }
}