using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using System.Net.Http;
using static UIKit.UIGestureRecognizer;
using StepByStepXamarin.iOS.Helpers;

namespace StepByStepXamarin.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public Uri serviceURI;
        public AppDelegate()
        {
            serviceURI = new Uri("https://backend-siv.ardia.com.tn:17905/siv/api/line/all/code?v=%22%22&locale=fr");
        }
      
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            App.connectwifi = new ConnectToWifi();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());          
            return base.FinishedLaunching(app, options);
        }
     
        internal  void SignCertificate()
        {
            WebResponse response;
            try
            {
               // Task.Delay(100);
               // // use the SSL protocol (instead of TLS)
               // ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
               
               // // ignore any certificate complaints
               // ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
               // {
               //     return true;
               // };
               // // create HTTP web request with proper content type
               // HttpWebRequest request =
               //     WebRequest.Create("https://backend-siv.ardia.com.tn:17905/siv/api/line/all/code?v=%22%22&locale=fr") as
               //         HttpWebRequest;
               // request.ContentType = "application/xml;charset=UTF8";
               // HttpClient client = new HttpClient();
            
               // // grab the PFX as a X.509 certificate from disk
               // string certFileName = Path.Combine("sivcertif.crt");
               //// load the X.509 certificate and add to the web request
               //X509Certificate cert = new X509Certificate(certFileName);
               // request.ClientCertificates.Add(cert);
               // request.PreAuthenticate = true;
               // response = request.GetResponse();
               // //Task.Run(() => client.GetStringAsync("https://backend-siv.ardia.com.tn:17905/siv/api/line/all/code?v=%22%22&locale=fr")).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                
                var type= ex.GetType().ToString();
               var msg= ex.Message;
                var ExceptionToString = ex.ToString();
                //Used for debugging certificate path.
                //responseDto.ExceptionMessage += " Certificate path: "+requestDto.CertificatePath;
                if (ex.InnerException != null)
                {
                    var ExceptionMessage  = " InnerException: " + ex.InnerException.Message;
                }

                if (ex is WebException)
                {
                    //Casting Exception to webException.
                    WebException webException = (WebException)ex;
                    //We can extract HttpWebResponse from WebResponse.
                    WebResponse webResponse = webException.Response;
                    if (webResponse != null)
                    {
                        //Casting WebException.Response to HttpWebResponse.
                        HttpWebResponse httpWebResponse = (HttpWebResponse)webException.Response;
                    }
                }
                //As discussed above, HttpWebRequest.GetResponse() throws an exception (WebException) to anyhthing else then a StatusCode 200.
                //But we want to handle other exceptions out in the code, therefore we rethrow the exception if it's not WebException.
                else
                {
                 

                    throw ex;
                }
            }
        }

        //public Task<HttpResponseMessage> Test()
        //{
        //    string url = "http://www.stackoverflow.com";
        //    var client = new HttpClient();
        //    return client.GetAsync(url).ContinueWith(request =>
        //    {
        //        var response = request.Result;
        //        response.EnsureSuccessStatusCode();
        //        return response.Content.ReadAsStringAsync().ContinueWith(t =>
        //        {
        //            var result = new HttpResponseMessage();
        //            response.CreateContent(t.Result);
        //            return response;
        //        });
        //    }).Unwrap();
        //}
    }
}
