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
using System.Windows.Media.Imaging;

namespace myWeatherApp
{
    public partial class weatherInfo : PhoneApplicationPage
    {
        public weatherInfo()
        {
            InitializeComponent();
        }
    

     protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
           base.OnNavigatedTo(e);

         // display weather
            //txtTitle.Text = App.wDB.strTitle;

            txtCurrentWeather.Text = string.Format(App.wDB.strTitle +  
                                                    "{0}Temp: " + App.wDB.strtemp + " " + App.wDB.strtempUnit +
                                                    "{0}Condition:  " + App.wDB.strctext+
                                                    "{0}Wind Speed: " + App.wDB.strcwindspeed + " " + App.wDB.strspeedUnit +
                                                    "{0}Humidity:  " + App.wDB.strchumid+
                                                    "{0}Pressure: " + App.wDB.strcatmpressure + " " + App.wDB.strpressureUnit +
                                                    "{0}Sunrise Time:  " + App.wDB.strsunrisetime+ 
                                                    "{0}Sunset Time:  " + App.wDB.strsunsettime
                                                    , Environment.NewLine);

            txtForecastWeather.Text = string.Format(App.wDB.strfday + ", " + App.wDB.strfdate + ": "+
                                                       "{0}Temp Range: " + App.wDB.strflow + App.wDB.strtempUnit + " to " + App.wDB.strfhigh + App.wDB.strtempUnit +
                                                       "{0}Condition:  " + App.wDB.strctext, Environment.NewLine);

           
            //Showing the image
            //string desc = App.wDB.strDesc;
           
         }

    
     }
}