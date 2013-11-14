using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Microsoft.Phone.Shell;

namespace myWeatherApp
{

    // 
    public class weatherDetails
    {
        //common to both
        public string strtempUnit = string.Empty;

        //Current data
        public string strTitle = string.Empty;
        public string strtemp = string.Empty;
        public string strctext = string.Empty;
        public string strcwindspeed = string.Empty;
        public string strspeedUnit = string.Empty;
        public string strchumid = string.Empty;
        public string strcatmpressure = string.Empty;
        public string strpressureUnit = string.Empty;
        public string strsunsettime = string.Empty;
        public string strsunrisetime = string.Empty;
        
        //forecast data
        public string strfday = string.Empty;
        public string strfdate = string.Empty;
        public string strftext = string.Empty;
        public string strfhigh = string.Empty;
        public string strflow = string.Empty;
    }


//Classes to hold complete JSON data***************************************************
public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
    }

public class Units
{
   public string distance { get; set; }
   public string pressure { get; set; }
   public string speed { get; set; }
   public string temperature { get; set; }
}

public class Wind
{
   public string chill { get; set; }
   public string direction { get; set; }
   public string speed { get; set; }
}

public class Atmosphere
{
   public string humidity { get; set; }
   public string pressure { get; set; }
   public string rising { get; set; }
   public string visibility { get; set; }
}

public class Astronomy
{
   public string sunrise { get; set; }
   public string sunset { get; set; }
}

//public class Image
//{
//    public string title { get; set; }
//    public string width { get; set; }
//    public string height { get; set; }
//    public string link { get; set; }
//    public string url { get; set; }
//}

public class Condition
{
   public string code { get; set; }
   public string date { get; set; }
   public string temp { get; set; }
   public string text { get; set; }
}

public class Forecast
{
   public string code { get; set; }
   public string date { get; set; }
   public string day { get; set; }
   public string high { get; set; }
   public string low { get; set; }
   public string text { get; set; }
}

public class Guid
{
    public string isPermaLink { get; set; }
    public string content { get; set; }
}

public class Item
{
   public string title { get; set; }
   public string lat { get; set; }
   public string @long { get; set; }
   public string link { get; set; }
   public string pubDate { get; set; }
   public Condition condition { get; set; }
   public string description { get; set; }
   public List<Forecast> forecast { get; set; }
   public Guid guid { get; set; }
}

public class Channel
{
    public string title { get; set; }
    public string link { get; set; }
    public string description { get; set; }
    public string language { get; set; }
    public string lastBuildDate { get; set; }
    public string ttl { get; set; }
    public Location location { get; set; }
    public Units units { get; set; }
    public Wind wind { get; set; }
    public Atmosphere atmosphere { get; set; }
    public Astronomy astronomy { get; set; }
    //public Image image { get; set; }
    public Item item { get; set; }
}

public class Results
{
    public Channel channel { get; set; }
}

public class Query
{
    public int count { get; set; }
    public string created { get; set; }
    public string lang { get; set; }
    public Results results { get; set; }
}

public class RootObject
{
    public Query query { get; set; }

}
// JASON Data holder classes end**********************

// Tombstoning classes
public class TransientDataStorage : IDataStorage
{

    public bool Backup(string token, object value)
    {
        if (null == value)
            return false;

        var store = PhoneApplicationService.Current.State;
        if (store.ContainsKey(token))
            store[token] = value;
        else
            store.Add(token, value);

        return true;
    }

    public T Restore<T>(string token)
    {
        var store = PhoneApplicationService.Current.State;
        if (!store.ContainsKey(token))
            return default(T);

        return (T)store[token];
    }
}


public interface IDataStorage
{
    bool Backup(string token, object value);
    T Restore<T>(string token);
}

}
