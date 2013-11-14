﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace myWeatherApp
{
    public partial class App : Application
    {
        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }
        public static weatherDetails wDB;

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            
            
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

            //Global Object for weather details.
            wDB = new weatherDetails();



        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            if (e.IsApplicationInstancePreserved)
            {
                //do nothing
            }
            else
            {
               
                var tombstore = new TransientDataStorage();

                wDB.strtempUnit = tombstore.Restore<string>("Unit");

                wDB.strtemp = tombstore.Restore<string>("tempt");
                wDB.strTitle = tombstore.Restore<string>("title");
                wDB.strctext = tombstore.Restore<string>("cText");
                wDB.strcwindspeed = tombstore.Restore<string>("cWindSpeed");
                wDB.strspeedUnit = tombstore.Restore<string>("cSpeedUnit");
                wDB.strchumid = tombstore.Restore<string>("cHumidity");
                wDB.strcatmpressure = tombstore.Restore<string>("cPressure");
                wDB.strpressureUnit = tombstore.Restore<string>("cPressureUnit");
                wDB.strsunsettime = tombstore.Restore<string>("cSunset");
                wDB.strsunrisetime = tombstore.Restore<string>("cSunrise");
      
                wDB.strfdate = tombstore.Restore<string>("fdate");
                wDB.strfday = tombstore.Restore<string>("fday");
                wDB.strftext = tombstore.Restore<string>("fText");
                wDB.strfhigh = tombstore.Restore<string>("fhigh");
                wDB.strflow = tombstore.Restore<string>("flow");

            }
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            var tombstore = new TransientDataStorage();

            tombstore.Backup("Unit", App.wDB.strtempUnit);

            tombstore.Backup("tempt", wDB.strtemp);
            tombstore.Backup("title", wDB.strTitle);
            tombstore.Backup("cText", wDB.strctext);

            tombstore.Backup("cWindSpeed", wDB.strcwindspeed);
            tombstore.Backup("cSpeedUnit", wDB.strspeedUnit);
            tombstore.Backup("cHumidity", wDB.strchumid);
            tombstore.Backup("cPressure", wDB.strcatmpressure);
            tombstore.Backup("cPressureUnit", wDB.strpressureUnit);
            tombstore.Backup("cSunset", wDB.strsunsettime);
            tombstore.Backup("cSunrise", wDB.strsunrisetime);
            
            tombstore.Backup("fdate", wDB.strfdate);
            tombstore.Backup("fday", wDB.strfday);
            tombstore.Backup("fText", wDB.strftext);
            tombstore.Backup("fhigh", wDB.strfhigh);
            tombstore.Backup("flow", wDB.strflow);
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}