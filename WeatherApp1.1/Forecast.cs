using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherApp1._1
{
    public class Forecast
    {
        public string weatherdata { get; set; }
    }
    public class Weatherdata
    {
        public string forecast { get; set; }
    }
    public class Forecastdata
    {
        public List<WeatherData> weatherdata { get; set; }
        public string time { get; set; }
    }
    public class Time
    {
        public List<Time> time { get; set; }
        public double temp { get; set; }
    }
}