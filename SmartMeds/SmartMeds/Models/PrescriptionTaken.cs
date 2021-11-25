using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMeds.Models
{
    class PrescriptionTaken
    {
        public DateTime TimeTaken { get; set; }
        public int PrescriptionID { get; set; }

        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }

        public PrescriptionTaken() { }

        public PrescriptionTaken(int _prescriptionID, DateTime _timeTaken)
        {
            PrescriptionID = _prescriptionID;
            TimeTaken = _timeTaken;
        }
    }
}
