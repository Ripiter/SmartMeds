using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SmartMeds.Models;
using System.Diagnostics;
using SmartMeds;

namespace SmartMeds
{
    public partial class MainPage : ContentPage, ITick
    {
        DataController dataController = new DataController();
        List<Prescription> prescriptions;

        INotificationManager notificationManager;
        public MainPage()
        {
            InitializeComponent();

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += NotificationRecived;
            //notificationManager.SendNotification("abc", "abcd");

            TimeTick.MinuteTick += MinuteTickEvent;
            prescriptions = dataController.GetPrescriptions("1");
            Histroy_btn.Clicked += ShowHistoryPage;

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

   
            // Add titles on the top of the grid
            grid_v.Children.Add(new Label() { Text = "Start", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 0, 0);
            grid_v.Children.Add(new Label() { Text = "End", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 1, 0);
            grid_v.Children.Add(new Label() { Text = "Description", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 2, 0);
            grid_v.Children.Add(new Label() { Text = "Amount", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 3, 0);
            grid_v.Children.Add(new Label() { Text = "Type", FontAttributes = FontAttributes.Bold, FontSize = 19 }, 4, 0);
        }

        private void NotificationRecived(object sender, EventArgs e)
        {
            var evtData = (NotificationEventArgs)e;
           ShowNotification(evtData.Title, evtData.Message);
        }
   
        private void ShowNotification(string title, string message)
        {
            throw new NotImplementedException();
        }

        private void ShowHistoryPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MedsHistory());
        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            if(sender is Label l)
            {
                Debug.WriteLine($"Row: {Grid.GetRow(l)} Col: {Grid.GetColumn(l)}");
                int rowIndex = Grid.GetRow(l);

                if (prescriptions != null)
                {
                    if (prescriptions.Count >= rowIndex - 1 && rowIndex - 1 >= 0)
                    {
                        Debug.WriteLine($"{prescriptions[rowIndex - 1].DebugString()}");
                        await Navigation.PushAsync(new SinglePrescriptionPage(prescriptions[rowIndex - 1]));
                    }
                }
            }
        }


        public void MinuteTickEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("1 minute has passed");
        }
    }
}
