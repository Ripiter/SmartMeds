using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartMeds.Models;

namespace SmartMeds.DB
{
    class PrescriptionDB : DBController
    {
        public override Task<List<T>> GetItemsAsync<T>()
        {
            return (Task<List<T>>)Convert.ChangeType(Database.Table<Prescription>().ToListAsync(), typeof(T));
        }

        protected override T RunQuery<T>(string query)
        {
            return (T)Convert.ChangeType(Database.QueryAsync<Prescription>(query), typeof(T));
        }
    }
}
