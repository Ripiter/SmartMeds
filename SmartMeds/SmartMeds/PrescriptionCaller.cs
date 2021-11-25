using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartMeds.Models;

namespace SmartMeds
{
    class PrescriptionCaller
    {
        public List<Prescription> GetPrescriptions(string userID)
        {
            List<Prescription> prescriptions = new List<Prescription>
            {
                new Prescription(1, DateTime.Now, null, "Take after meal", new Preparation(TypeAmount.g, 1)),
                new Prescription(2, DateTime.Now.AddDays(1), null, "After toilet", new Preparation(TypeAmount.liters, 3)),
                new Prescription(3, DateTime.Now.AddDays(2), DateTime.Now.AddDays(365), "Every Morning", new Preparation(TypeAmount.mg, 30))
            };

            return prescriptions;
        }


        public Prescription GetPrescription(string prescriptionID)
        {
            return null;
        }
    }
}
