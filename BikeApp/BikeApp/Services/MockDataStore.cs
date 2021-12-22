using SQLite;
using BikeApp.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeApp.Services.Alert;

namespace BikeApp.Services
{
    public class MockDataStore : IDataStore<Route>
    {
        readonly List<Route> items;
        private readonly SQLiteConnection sqlConn;
        private static readonly string sqlDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "datastore.db3");

        public MockDataStore()
        {
            /*
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
            */
            

            sqlConn = new SQLiteConnection(sqlDbPath);
            sqlConn.CreateTable<Route>();

            items = sqlConn.Table<Route>().ToList();
        }

        public async Task<bool> AddItemAsync(Route item)
        {
           
            items.Add(item);
            sqlConn.Insert(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Route item)
        {
            var oldItem = items.Where((Route arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            sqlConn.Delete(oldItem.Id);
            sqlConn.Insert(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Route arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);
            sqlConn.Delete(oldItem.Id);

            return await Task.FromResult(true);
        }

        public async Task<Route> GetItemAsync(string id)
        {
            //no need to interact with the database
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Route>> GetItemsAsync(bool forceRefresh = false)
        {
            //no need to interact with the database
            return await Task.FromResult(items);
        }
    }
}