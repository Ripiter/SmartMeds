using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMeds.Models
{
    public class Prescription
    {
        public Prescription() { }
        public Prescription(int _id, DateTime _startDate, DateTime? _endDate, string _description, Preparation _preparation) 
        {
            ID = _id;
            StartDate = _startDate;
            EndDate = _endDate;
            Preparation = _preparation;
            Description = _description;
            preparationJson = JsonConvert.SerializeObject(preparation);
        }

        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        private string preparationJson;

        public string PreparationJson
        {
            get { return preparationJson; }
            set { preparationJson = value; }
        }


        private Preparation preparation;

        [SQLite.Ignore]
        public Preparation Preparation
        {
            get { return GetPrepation(); }
            set { preparation = value; }
        }


        protected Preparation GetPrepation()
        {
            if (preparation == null)
                return JsonConvert.DeserializeObject<Preparation>(PreparationJson);
            else
                return preparation;
        }
        //public Preparation Preparation { get; set; }

        public string GetEndDate(string _dateFormat = "dd/MM-yyyy")
        {
            return EndDate?.ToString(_dateFormat);
        }
        public string GetStartDate(string _dateFormat = "dd/MM-yyyy")
        {
            return StartDate.ToString(_dateFormat);
        }

        public string DebugString()
        {
            return $"ID: [{ID}] Start [{GetStartDate()}] End:[{GetEndDate()}] " +
                    $"Description: [{Description}] Type: [{Preparation.Item}] Amount: [{Preparation.Amount}]";
        }
    }
}
