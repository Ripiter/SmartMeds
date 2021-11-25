using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartMeds.Models;

namespace SmartMeds.DB
{
    class PrescriptionTakenDB : PrescriptionDB
    {
        public override Task<List<T>> GetItemsAsync<T>()
        {
            return (Task<List<T>>)Convert.ChangeType(Database.Table<PrescriptionTaken>().ToListAsync(), typeof(T));
        }

        public Task<List<Prescription>> GetItemsAsynctest()
        {
            return Database.Table<Prescription>().ToListAsync();
        }

        protected override T RunQuery<T>(string query)
        {
            return (T)Convert.ChangeType(Database.QueryAsync<PrescriptionTaken>(query), typeof(T));
        }

        public Task<List<PrescriptionTaken>> GetBetweenDates(DateTime from, DateTime to)
        {
            return RunQuery<Task<List<PrescriptionTaken>>>("SELECT * FROM [PrescriptionTaken]");
        }



        //public override Task<List<PrescriptionTaken>> GetItemsAsync<T>()
        //{
        //    return Database.Table<PrescriptionTaken>().ToListAsync();
        //}
        //public Task<List<PrescriptionTaken>> GetItems()
        //{
        //    return Database.Table<PrescriptionTaken>().ToListAsync();
        //}


    }
}