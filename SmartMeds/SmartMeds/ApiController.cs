using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartMeds.Models;

namespace SmartMeds
{
    public class ApiController
    {
        PrescriptionCaller prescriptionCaller;

        public ApiController()
        {
            prescriptionCaller = new PrescriptionCaller();
        }

        public List<Prescription> GetPrescriptions(string userID)
        {
            return prescriptionCaller.GetPrescriptions(userID);
        }

        public Prescription GetPrescriptionById(int id)
        {
            return prescriptionCaller.GetPrescription(id);
        }
    }
}
