﻿#pragma checksum "E:\Wphone\Assignment2_Weatherapp\myWeatherApp\myWeatherApp\weatherInfo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0AFA2AC082D50D82A678ED3DB4A7C08A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17379
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace myWeatherApp {
    
    
    public partial class weatherInfo : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox p2_textBox_currentWeather;
        
        internal System.Windows.Controls.TextBlock txtCurrentWeather;
        
        internal System.Windows.Controls.TextBlock txtForecastWeather;
        
        internal System.Windows.Controls.TextBox p1_textBox1_forecastWeather;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Assignment2;component/weatherInfo.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.p2_textBox_currentWeather = ((System.Windows.Controls.TextBox)(this.FindName("p2_textBox_currentWeather")));
            this.txtCurrentWeather = ((System.Windows.Controls.TextBlock)(this.FindName("txtCurrentWeather")));
            this.txtForecastWeather = ((System.Windows.Controls.TextBlock)(this.FindName("txtForecastWeather")));
            this.p1_textBox1_forecastWeather = ((System.Windows.Controls.TextBox)(this.FindName("p1_textBox1_forecastWeather")));
        }
    }
}

