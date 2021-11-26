using System;
using System.Collections.Generic;
using System.Text;
using SmartMeds.Models;
using SmartMeds.DB;

namespace SmartMeds
{
    class DataController
    {
        ApiController apiController = null;

        public DataController()
        {
            apiController = new ApiController();
        }

        public List<Prescription> GetPrescriptions(string userID)
        {
            List<Prescription> prescriptions = apiController.GetPrescriptions(userID);
            PrescriptionDB prescriptionDB = new PrescriptionDB();

            prescriptionDB.SaveItems(prescriptions);

            return prescriptions;
        }

        public List<PrescriptionTaken> GetPrescriptionsTaken()
        {
            PrescriptionTakenDB takenDB = new PrescriptionTakenDB();

            return takenDB.GetItemsAsync<PrescriptionTaken>().Result;
        }

        public Prescription GetPrescriptionById(int id)
        {
            return apiController.GetPrescriptionById(id);
        }

        public bool TakePrescription(Prescription prescription)
        {
            PrescriptionTakenDB takenDB = new PrescriptionTakenDB();
            return takenDB.SaveItemAsync(new PrescriptionTaken(prescription.ID, DateTime.Now)).Result == 1 ? true : false;
        }
    }
}
