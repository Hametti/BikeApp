using BikeApp.Data.Themes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeApp.Data.Helpers
{
    public class Initializer
    {
        public static void LoadTheme()
        {
            //There will be a loading from deserialized object(setup file) here in the future
            CurrentTheme.SetTheme(new DarkTheme());
        }
    }
}
