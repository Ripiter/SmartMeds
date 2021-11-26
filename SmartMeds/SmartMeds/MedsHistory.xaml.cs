using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartMeds.Models;
using System.Diagnostics;

namespace SmartMeds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedsHistory : ContentPage
    {
        DataController dataController = null;
        public MedsHistory()
        {
            InitializeComponent();
            dataController = new DataController();
            histort_lv.ItemTapped += ItemTapped;
            List<PrescriptionTaken> prescriptionsTaken = dataController.GetPrescriptionsTaken();
            if(prescriptionsTaken.Count > 0)
            {
                histort_lv.ItemsSource = prescriptionsTaken;
                // this is a test to see if it works 
                //Prescription prescription = dataController.GetPrescriptionById(prescriptionsTaken[0].PrescriptionID);
            }
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
                return;

            if(e.Item is PrescriptionTaken p)
            {
                Navigation.PushAsync(new SinglePrescriptionPage(dataController.GetPrescriptionById(p.PrescriptionID), true));
            }
        }
    }
}