using System;
using System.Collections.Generic;
using System.Text;

namespace BikeApp.Data.Themes
{
    public static class CurrentTheme
    {
        public static string BackgroundColor1 { get; set; }
        public static string BackgroundColor2 { get; set; }
        public static string BackgroundColor3 { get; set; }
        public static string ButtonColor { get; set; }
        public static string TextColor { get; set; }
        public static void SetTheme(ThemeModel theme)
        {
            BackgroundColor1 = theme.BackgroundColor1;
            BackgroundColor2 = theme.BackgroundColor2;
            BackgroundColor3 = theme.BackgroundColor3;
            ButtonColor = theme.ButtonColor;
            TextColor = theme.TextColor;
        }
    }
}
