using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartMeds.Models;

namespace SmartMeds.DB
{
    class PrescriptionTakenDB : DBController
    {
        public override Task<List<T>> GetItemsAsync<T>()
        {
            return (Task<List<T>>)Convert.ChangeType(Database.Table<PrescriptionTaken>().ToListAsync(), typeof(Task<List<PrescriptionTaken>>));
        }
        public List<PrescriptionTaken> GetItems2()
        {
            return Database.Table<PrescriptionTaken>().ToListAsync().Result;
        }


        protected override T RunQuery<T>(string query)
        {
            return (T)Convert.ChangeType(Database.QueryAsync<PrescriptionTaken>(query), typeof(T));
        }

        public Task<List<PrescriptionTaken>> GetBetweenDates(DateTime from, DateTime to)
        {
            return RunQuery<Task<List<PrescriptionTaken>>>("SELECT * FROM [PrescriptionTaken]");
        }
    }
}