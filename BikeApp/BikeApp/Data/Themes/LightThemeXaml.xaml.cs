using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp.Data.Themes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LightThemeXaml : ResourceDictionary
    {
        public ObservableCollection<string> Items { get; set; }

        public LightThemeXaml()
        {
            InitializeComponent();
        }
    }
}
