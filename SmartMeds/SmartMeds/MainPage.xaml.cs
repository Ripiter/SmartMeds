using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SmartMeds.Models;
using System.Diagnostics;

// Test
using SmartMeds.DB;

namespace SmartMeds
{
    public partial class MainPage : ContentPage, ITick
    {
        ApiController apiController = new ApiController();
        List<Prescription> prescriptions;

        public MainPage()
        {
            InitializeComponent();
            TimeTick.MinuteTick += MinuteTickEvent;
            prescriptions = apiController.GetPrescriptions("1");

            //TableView tv = new TableView();
            //tv.Root = new TableRoot();
            //TableSection cells = new TableSection();

            //for (int i = 0; i < prescriptions.Count; i++)
            //{
            //    cells.Add(new TextCell() { Text = $"Start [{prescriptions[i].GetStartDate()}] End:[{prescriptions[i].GetEndDate()}] " +
            //        $"Description: [{prescriptions[i].Description}] Type: [{prescriptions[i].Preparation.Item}] Amount: [{prescriptions[i].Preparation.Amount}]"
            //    });
            //}


            //tv.Root.Add(cells);
            //tv.Intent = TableIntent.Data;

            //Content = tv;

            // for each property
            for (int i = 0; i < 5; i++)
            {
                grid_v.ColumnDefinitions.Add(new ColumnDefinition() {  Width = GridLength.Star });
            }

            // for the titles
            grid_v.RowDefinitions.Add(new RowDefinition() { Height = 30 });

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;

            for (int i = 0; i < prescriptions.Count; i++)
            {         
                grid_v.RowDefinitions.Add(new RowDefinition());                
                
                Label startDateLabel = new Label();
                startDateLabel.Text = prescriptions[i].GetStartDate();   

                Label endDateLabel = new Label();
                endDateLabel.Text = prescriptions[i].GetEndDate();

                Label descriptionLabel = new Label();
                descriptionLabel.Text = prescriptions[i].Description;

                Label amountLabel = new Label();
                amountLabel.Text = prescriptions[i].Preparation.Amount.ToString();

                Label typeLabel = new Label();
                typeLabel.Text = prescriptions[i].Preparation.Item.ToString();


                grid_v.Children.Add(startDateLabel, 0, i + 1);
                grid_v.Children.Add(endDateLabel, 1, i + 1);
                grid_v.Children.Add(descriptionLabel, 2, i + 1);
                grid_v.Children.Add(amountLabel, 3, i + 1);
                grid_v.Children.Add(typeLabel, 4, i + 1);
            }

            for (int i = 0; i < grid_v.Children.Count; i++)
            {
                grid_v.Children[i].GestureRecognizers.Add(tap);
            }

   
            grid_v.Children.Add(new Label() { Text = "Start", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 0, 0);
            grid_v.Children.Add(new Label() { Text = "End", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 1, 0);
            grid_v.Children.Add(new Label() { Text = "Description", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 2, 0);
            grid_v.Children.Add(new Label() { Text = "Amount", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 3, 0);
            grid_v.Children.Add(new Label() { Text = "Type", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 4, 0);
        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            if(sender is Label l)
            {
                Debug.WriteLine($"Row: {Grid.GetRow(l)} Col: {Grid.GetColumn(l)}");
                int i = Grid.GetRow(l);

                if (prescriptions != null)
                {
                    if (prescriptions.Count >= i - 1 && i - 1 >= 0)
                    {
                        Debug.WriteLine($"{prescriptions[i - 1].DebugString()}");
                        PrescriptionTakenDB db = new PrescriptionTakenDB();
                        int r = db.SaveItemAsync<PrescriptionTaken>(new PrescriptionTaken(0, DateTime.Now)).Result;
                        List<PrescriptionTaken> item = db.GetBetweenDates(DateTime.Now, DateTime.Now).Result;
                        int r2 = db.SaveItemAsync(prescriptions[i - 1]).Result;
                        List<Prescription> lp = db.GetItemsAsynctest().Result;
                        //int r = db.SaveItemAsync(new PrescriptionTaken(prescriptions[i - 1].ID, DateTime.Now)).Result;
                        //List<PrescriptionTaken> items = db.GetItemsAsync<PrescriptionTaken>().Result;   
                    }
                }
            }
        }

        void ShowNotification(string title, string message)
        {
            Debug.WriteLine($"Title: {title} Msg: {message}");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            List<Prescription> prescriptions = apiController.GetPrescriptions("1");

            for (int i = 0; i < prescriptions.Count; i++)
            {
                //Debug.WriteLine($"Start [{prescriptions[i].GetStartDate()}] End:[{prescriptions[i].GetEndDate()}] " +
                    //$"Description: [{prescriptions[i].Description}] Type: [{prescriptions[i].Preparation.Item}] Amount: [{prescriptions[i].Preparation.Amount}]");
            }
        }

        public void MinuteTickEvent(object sender, EventArgs e)
        {
            string title = $"Jojo";
            string message = $"1 minute has passed";
            //notificationManager.SendNotification(title, message);
            ShowNotification(title, message);
        }
    }

    class A
    {

    }
    class B : A
    {

    }
}
