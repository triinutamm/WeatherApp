using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherApp1._1
{
    [Activity(Label = "ForecastActivity")]
    public class ForecastActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.forecast_activity);
            var button = FindViewById<Button>(Resource.Id.button);
            button.Click += Button_ClickAsync;

            // Create your application here
        }

        private async void Button_ClickAsync(object sender, EventArgs e)
        {
            var input = FindViewById<EditText>(Resource.Id.input);
            var city = input.Text;
            string path = "http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=b6907d289e10d714a6e88b30761fae22&units=metric";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            HttpContent content = response.Content;
            dynamic result = await content.ReadAsStringAsync();

            int x = 0;
        }
    }
}