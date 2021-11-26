using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SmartMeds.Models;
using System.Threading.Tasks;

namespace SmartMeds.DB
{
    abstract class DBController
    {
        protected SQLiteAsyncConnection Database;
        protected bool tablesCreated = false;

        public void CreateTables()
        {
            if (tablesCreated == false)
            {
                CreateTableResult result = Database.CreateTableAsync<PrescriptionTaken>().Result;
                CreateTableResult result2 = Database.CreateTableAsync<Prescription>().Result;
                tablesCreated = true;
            }
        }

        public DBController()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            CreateTables();
        }
        public abstract Task<List<T>> GetItemsAsync<T>();

        //DateTime from, DateTime to, 
        protected abstract T RunQuery<T>(string query);
        //{
        //    // SQL queries are also possible
        //    // "SELECT * FROM [PrescriptionTaken]"
        //    return Database.QueryAsync<T>(query);
        //}

        public Task<List<PrescriptionTaken>> GetTopItems(int top)
        {
            // SQL queries are also possible
            return Database.QueryAsync<PrescriptionTaken>("SELECT * FROM PrescriptionTaken limit" + top);
        }

        public Task<PrescriptionTaken> GetItemAsync(int id)
        {
            return Database.Table<PrescriptionTaken>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateItemAsync<T>(T item)
        {
            return Database.UpdateAsync(item);
        }

        public Task<int> SaveItemAsync<T>(T item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> SaveItems<T>(List<T> items)
        {
            return Database.InsertOrReplaceAsync(items);
        }

        public Task<int> DeleteItemAsync<T>(T item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
