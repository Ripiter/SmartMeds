using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMeds
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //DependencyService.Register<INotificationManager>();
            DependencyService.Get<SmartMeds.INotificationManager>().Initialize();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            TimeTick.Start();
        }

        protected override void OnSleep()
        {
            TimeTick.Stop();
        }

        protected override void OnResume()
        {
            TimeTick.Start();
        }
    }
}
