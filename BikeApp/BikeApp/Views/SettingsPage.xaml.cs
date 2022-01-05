using BikeApp.Data.Themes;
using BikeApp.Services.Alert;
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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            Resources["LabelStyle"] = Resources["DarkThemeLabelStyle"];
            Resources["ContentPageStyle"] = Resources["DarkThemeContentPageStyle"];
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
            ((Label)FindByName("Label2")).TextColor = Color.FromHex(CurrentTheme.TextColor);
        }

        private void Switch_DarkMode(object sender, ToggledEventArgs isToggled)
        {
            //ICollection<ResourceDictionary> mergedDicts = Application.Current.Resources.MergedDictionaries;
            //AlertService.ShowMessage("mergedDicts length", $"{mergedDicts.Count}", "OK");
            //mergedDicts.Clear();
            if (isToggled.Value)
            {
                //CurrentTheme.SetTheme(new DarkTheme());
                //mergedDicts.Add(new DarkThemeXaml());
                Resources["LabelStyle"] = Resources["DarkThemeLabelStyle"];
                Resources["ContentPageStyle"] = Resources["DarkThemeContentPageStyle"];
            }
            else
            {
                //CurrentTheme.SetTheme(new LightTheme());
                //mergedDicts.Add(new LightThemeXaml());
                Resources["LabelStyle"] = Resources["LightThemeLabelStyle"];
                Resources["ContentPageStyle"] = Resources["LightThemeContentPageStyle"];
            }
                

            UpdateLayout();
        }
        private void Switch_MeasureBackground(object sender, ToggledEventArgs isToggled)
        {
            //...
        }
        void Button_SaveChanges(object sender, System.EventArgs e)
        {
            //interact with database and save changes, etc.
        }
    }
}