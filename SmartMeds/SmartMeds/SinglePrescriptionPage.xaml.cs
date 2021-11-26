using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartMeds.Models;

namespace SmartMeds
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SinglePrescriptionPage : ContentPage
    {
        DataController dataController = null;
        Prescription prescription = null;
        public SinglePrescriptionPage()
        {
            InitializeComponent();
        }

        public SinglePrescriptionPage(Prescription _prescription, bool _prescriptionTaken = false)
        {
            InitializeComponent();
            prescription = _prescription;

            StartDate_Text.Text = "Start Date " + _prescription.GetStartDate();
            EndDate_Text.Text = "End Date " + _prescription.GetEndDate();
            Preparation_Text.Text = "Amount " + _prescription.Preparation.Amount.ToString() + " " + _prescription.Preparation.Item.ToString();
            Description_Text.Text = "Description " + _prescription.Description;

            if(_prescriptionTaken == true)
            {
                TakePrescription_btn.IsVisible = false;
                TakePrescription_btn.IsEnabled = false;
            }
            else
            {
                TakePrescription_btn.Clicked += TakePrescription_Clicked;
            }

            dataController = new DataController();
        }

        private void TakePrescription_Clicked(object sender, EventArgs e)
        {
            bool res = dataController.TakePrescription(prescription);

            if (res == false)
                Debug.WriteLine("Failed to add prescription");
        }
    }
}