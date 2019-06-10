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
    public class Weather
    {
        public string main { get; set; }
        public string icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }

    public class Sys
    {
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class WeatherData
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }
}