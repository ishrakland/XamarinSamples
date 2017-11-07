using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;
using Plugin.Connectivity;
using Xamarin.Forms.Xaml;

namespace StepByStepXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Connexion Test", " Error Your are not connected", "OK");
                App.connectwifi.setupWifi();
            }
            if (CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Connexion Test", "Your are connected", "OK");
            }

        }
      
         
        public MainPage()
        {
            InitializeComponent();

        }
    }
}
