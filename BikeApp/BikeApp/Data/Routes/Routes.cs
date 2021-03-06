using BikeApp.Models;
using BikeApp.Services.Alert;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BikeApp.Data.Routes
{
    public class Routes
    {
        public static List<Route> AllRoutes { get; set; } = new List<Route>();

        public static void Save()
        {
            var valueToSave = JsonConvert.SerializeObject(AllRoutes);
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(string));
            System.IO.FileStream file;

            //string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //AlertService.ShowMessage("Ok", documentsPath, "Ok");

            file = System.IO.File.Create("/data/user/0/student.bikeapp/files/RoutesList");
            writer.Serialize(file, valueToSave);

            file.Dispose();
            file.Close();
        }

        public static void Load()
        {
            if(System.IO.File.Exists("/data/user/0/student.bikeapp/files/RoutesList"))
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(string));
                System.IO.StreamReader file;

                file = new System.IO.StreamReader("/data/user/0/student.bikeapp/files/RoutesList");

                var serializedJson = (string)reader.Deserialize(file);
                AllRoutes = JsonConvert.DeserializeObject<List<Route>>(serializedJson);

                file.Dispose();
                file.Close();
            }
        }
    }
}
