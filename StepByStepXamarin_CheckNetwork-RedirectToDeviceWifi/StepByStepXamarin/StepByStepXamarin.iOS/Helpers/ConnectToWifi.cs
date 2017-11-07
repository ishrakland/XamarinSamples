using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StepByStepXamarin.iOS.Helpers
{
    public class ConnectToWifi : IConnectToWifi
    {
        public void setupWifi()
        {
            Device.OpenUri(new Uri(string.Format("App-prefs:root=WIFI")));
        }
    }
}
