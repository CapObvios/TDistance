using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TravelDistance.LD;
using TravelDistance.GDST;
using System.Windows.Threading;
using System.Windows.Forms;



namespace TravelDistance
{
    public class Program
    {
       

        public static string MakeLocationQuery()
        {
            return string.Format("http://ip-api.com/json");
        }

        public async Task LocationUseWebClient()
        {
            var webClientLct = new WebClient();
            await Task.Factory.StartNew(() => Lct(webClientLct));
        }

        public void Lct(WebClient webClient)
        {
            try
            {
                var result = webClient.DownloadString(MakeLocationQuery());
                var final = JsonConvert.DeserializeObject<LocationData>(result);
                MainWindow.CallLct(new List<LocationData>() { final });
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message + "                     PLEASE RESTART THE PROGRAMM");
                
            }
            
        }

        public async Task DistanceUseWebClient(string CurCity, string CurCountry, string Destination, string mode)
        {
            var webClientDst = new WebClient();
            await Task.Factory.StartNew(() => Dst(webClientDst,  CurCity,  CurCountry,  Destination, mode));
        }

        public void Dst(WebClient webClient, string CurCity, string CurCountry, string Destination, string mode)
        {
            try
            {
                var result = webClient.DownloadString(MakeDistanceQuery(CurCity, CurCountry, Destination, mode));
                var finalDst = JsonConvert.DeserializeObject<General>(result);
                MainWindow.CallDst(new List<General>() { finalDst });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }


        //public LocationData SuperLocationUseWebClient()
        //{
        //    try
        //    {

        //        var webClient = new WebClient();
        //        string result = webClient.DownloadString(MakeLocationQuery());
        //        return JsonConvert.DeserializeObject<LocationData>(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR:" + ex.Message);
        //        return null;
        //    }
           
        //}


        public const string GoogleAPI = "AIzaSyCV8qXcyY-r3JhZnmrlw0iXO0wn8sCxUWU";

        public static string MakeDistanceQuery(string CurCity, string CurCountry, string Destination, string mode)
        {
            return string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?origins={0}+{1}&destinations={2}&mode={3}&key={4}", CurCity, CurCountry, Destination.Replace(" ", "+"), mode, GoogleAPI);
        }

        // https://maps.googleapis.com/maps/api/distancematrix/json?origins=Seattle&destinations=San+Francisco&key=AIzaSyCV8qXcyY-r3JhZnmrlw0iXO0wn8sCxUWU


        //public General DistanceUseWebClient(string CurCity, string CurCountry, string Destination, string mod)
        //{
        //    var webClient = new WebClient();
        //    string result = webClient.DownloadString(MakeDistanceQuery(CurCity, CurCountry, Destination, mod));
        //    return JsonConvert.DeserializeObject<General>(result);
        //}
    }
}
