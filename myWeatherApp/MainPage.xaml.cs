using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime.Serialization.Json;

namespace myWeatherApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        // 'Get Weather' button click event on p1:
        private void p1_btn_GetWeather_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(p1_txt_woeid.Text))
            {

                MessageBox.Show("Please enter a valid yahoo WOEID");

            }
            else
                GetWeather(p1_txt_woeid.Text);
        }

        // Fetching the weather info from Yahoo Using JSON
        public void GetWeather(string woeid)
        {
            try
            {
                
                var wc = new WebClient();
                string uri = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%3D" + woeid + "&format=json&diagnostics=true&callback=";
 
                wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(weatherDataRecieved);
                wc.DownloadStringAsync(new Uri(uri));
            }
            catch (UriFormatException e)
            {
                MessageBox.Show("Please enter valid Yahoo WOEID, Example: 565346 for Helsinki, Finland");

            }
            catch (Exception e)
            {
                MessageBox.Show("Please enter valid Yahoo WOEID, Example: 565346 for Helsinki, Finland");
            }
        }

        // Parsing the JSON, weather details are parsed here.
        void weatherDataRecieved(object sender, DownloadStringCompletedEventArgs e)
        {
            //MessageBox.Show(e.Result);
            try
            {
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
                DataContractJsonSerializer srl = new DataContractJsonSerializer(typeof(RootObject));
                RootObject rootObject = (RootObject)(srl.ReadObject(ms));
                Query q = rootObject.query;
                Results r = q.results;
                Channel c = r.channel;
                Item i = c.item;
                Units u = c.units;
                Condition c1 = i.condition;
                Forecast f = i.forecast[1];
                Wind w = c.wind;
                Atmosphere a = c.atmosphere;
                Astronomy ast = c.astronomy;

            //Unit, to be used in both cases:
                App.wDB.strtempUnit = u.temperature;

            //Current Weather attributes:
                //Pushing current weather (to be used in UI) attributes to db for tombstoning use
                App.wDB.strTitle = i.title; //location & last observation date/time stamp 
                App.wDB.strctext = c1.text;
                App.wDB.strtemp = c1.temp;
                App.wDB.strcwindspeed = w.speed;
                App.wDB.strspeedUnit = u.speed;
                App.wDB.strchumid = a.humidity;
                App.wDB.strcatmpressure = a.pressure;
                App.wDB.strpressureUnit = u.pressure;
                App.wDB.strsunrisetime = ast.sunrise;
                App.wDB.strsunsettime = ast.sunset;

           //Forecast Weather attributes:
                //Pushing current weather (to be used in UI) attributes to db for tombstoning use
                App.wDB.strfday = f.day;
                App.wDB.strfdate = f.date;
                App.wDB.strftext = f.text;
                App.wDB.strfhigh = f.high;
                App.wDB.strflow = f.low;
                
                NavigationService.Navigate(new Uri("/weatherInfo.xaml", UriKind.Relative));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid yahoo WOID");
            }

        }
    }
}