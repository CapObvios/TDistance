using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TravelDistance.GDST;
using TravelDistance.LD;


namespace TravelDistance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate void _callbackDst(List<General> Distancedata);
    public delegate void _callbackLct(List<LocationData> LocationData);
    public partial class MainWindow : Window
    {
        public static _callbackLct CallLct;
        public static _callbackDst CallDst;
        Program p = new Program();

        public async void SetLoc()
        {

            await p.LocationUseWebClient();
            
        }

        public MainWindow()
        {


            InitializeComponent();
            CallLct = LocationSet;
            CallDst = DistanceSet;
            ApplyButton.IsEnabled = false;
            SetLoc();

            //  var Locdata = p.LocationUseWebClient();


        }

        private void DistanceSet(List<General> Distancedata)
        {
            Dispatcher.BeginInvoke(new Action(() =>
                    {


                        if (string.IsNullOrWhiteSpace(CityNameBox.Text))
                        {
                            DestBlock.Text = "Come on, type in at least something!";
                            TextBlock1.Text = "";
                            TextBlock2.Text = "";
                            CityNameBox.Text = "";
                        }
                        else if (Distancedata[0].dest[0] == "" || Distancedata[0].dest[0] == null)
                        {
                            DestBlock.Text = "Oops! That place wasn't found or even doesn't exist!";
                            TextBlock1.Text = "Try another one!";
                            TextBlock2.Text = "";
                        }
                        else
                        {
                            DestBlock.Text = Distancedata[0].dest[0];

                            if (Distancedata[0].rows[0].elements[0].status == "OK")
                            {
                                TextBlock1.Text = Distancedata[0].rows[0].elements[0].distance.text;
                                TextBlock2.Text = Distancedata[0].rows[0].elements[0].duration.text;
                            }
                            else
                            {
                                TextBlock1.Text = "No avialible roads were found!";
                                TextBlock2.Text = "Don't even try :Р";
                            }
                        }

                        if (mode == "driving")
                            transportBlock.Text = "      Time to get there by car is...";
                        else if (mode == "bicycling")
                            transportBlock.Text = "Time to get there on bicycle is...";
                        else
                            transportBlock.Text = "    Time to get there on foot is...";
                    }));
        }

        public List<LocationData> Loc = new List<LocationData>();
        private void LocationSet(List<LocationData> LocationData)
        {
            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Loc = LocationData;
                        if (Loc[0].city != Loc[0].reg)
                            CurrentCityBlock.Text = Loc[0].city + ", " + Loc[0].reg + " " + Loc[0].zip + ", " + Loc[0].country; //+ " (" + Loc[0].lat + " lat, " + Loc[0].lon + " lng)"; //" " + Loc[0].zip +
                        else
                            CurrentCityBlock.Text = Loc[0].city + ", " + Loc[0].country;

                        if (CurrentCityBlock.Text != "")
                        {
                            ApplyButton.IsEnabled = true;
                        }
                    }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured: " + ex.Message);
              //  Console.WriteLine("An error occured: " + ex.Message);
            }
        }

        private async void ApplyButton_Click(object sender, RoutedEventArgs e)
        {


            ApplyButton.IsEnabled = false;

            try
            {
                await p.DistanceUseWebClient(Loc[0].city, Loc[0].country, CityNameBox.Text, mode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
            
                
                ApplyButton.IsEnabled = true;
            
            //try
            //{
            //    var DistData = p.DistanceUseWebClient(p.LocationUseWebClient().city, p.LocationUseWebClient().country, CityNameBox.Text, mode);
            //    if (CityNameBox.Text == "")
            //    {
            //        DestBlock.Text = "Come on, type in at least something!";
            //        TextBlock1.Text = "";
            //        TextBlock2.Text = "";
            //    }
            //    else if (DistData.dest[0] == "" || DistData.dest[0] == null)
            //    {
            //        DestBlock.Text = "Oops! That place wasn't found or doesn't exist!";
            //        TextBlock1.Text = "";
            //        TextBlock2.Text = "";
            //    }
            //    else
            //    {
            //        DestBlock.Text = DistData.dest[0];

            //        if (DistData.rows[0].elements[0].status == "OK")
            //        {
            //            TextBlock1.Text = DistData.rows[0].elements[0].distance.text;
            //            TextBlock2.Text = DistData.rows[0].elements[0].duration.text;
            //        }
            //        else
            //        {
            //            TextBlock1.Text = "No avialible roads were found!";
            //            TextBlock2.Text = "Don't even try :Р";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("An error occured: " + ex.Message);
            //}




        }
        string mode = "driving";


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mode = "driving";
            //  transportBlock.Text = "      Time to get there by car is...";

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            mode = "bicycling";
            // transportBlock.Text = "Time to get there on bicycle is...";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            mode = "walking";
            //transportBlock.Text = "    Time to get there on foot is...";
        }
        //private void CityNameBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        ApplyButton_Click(sender, e);
        //    }
        //}
    }
}
