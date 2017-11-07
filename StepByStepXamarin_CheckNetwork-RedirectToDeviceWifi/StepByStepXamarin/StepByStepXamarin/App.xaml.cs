using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StepByStepXamarin
{
    public partial class App : Application
    {
        public static IConnectToWifi connectwifi { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new StepByStepXamarin.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public interface IConnectToWifi
    {
        void setupWifi();
    }
}
