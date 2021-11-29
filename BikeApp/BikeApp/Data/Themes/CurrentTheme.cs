using System;
using System.Collections.Generic;
using System.Text;

namespace BikeApp.Data.Themes
{
    public class CurrentTheme
    {
        public static ThemeModel CurrentLayout;
        public static void SetTheme(ThemeModel theme)
        {
            CurrentLayout = theme;
        }
    }
}
