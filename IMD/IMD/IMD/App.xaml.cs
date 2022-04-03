using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            // MainPage = new NavigationPage( new LoginUI());
            MainPage = new MyFlyoutPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
