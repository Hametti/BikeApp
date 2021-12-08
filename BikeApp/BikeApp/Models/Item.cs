using SQLite;
using System;


namespace BikeApp.Models
{
    public class Item
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}