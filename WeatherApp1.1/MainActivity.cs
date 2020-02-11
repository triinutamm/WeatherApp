using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Linq;
using Android.Graphics;
using System.Net;
using Android.Content;
using Android.Views;

namespace WeatherApp1._1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {   
        string queryurl;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           
            // Get forecast button
            var Button = FindViewById<Button>(Resource.Id.button1);
            Button.Click += Button_Click;
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            var cityname_ = FindViewById<EditText>(Resource.Id.cityname);
            string city = cityname_.Text.ToString();
            queryurl = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=6b5d1b98a1edd47d85f63100062b29bf" + "&units=metric";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(queryurl);
            HttpContent content = response.Content;
            dynamic result = await content.ReadAsStringAsync();

            WeatherData data = JsonConvert.DeserializeObject<WeatherData>(result);
            // Tee TextViewe juurde ja muuda tehtud variabled nendeks textviewideks
            var currentTemp = data.main.temp;
            var weatherTemperatureMin = data.main.temp_min;
            var weatherTemperatureMax = data.main.temp_max;
            var weatherWind = data.wind.speed;
            var weatherHumidity = data.main.humidity;

            var icon = data.weather.FirstOrDefault().icon;

            TextView Wind = FindViewById<TextView>(Resource.Id.wind);
            TextView Temp = FindViewById<TextView>(Resource.Id.temperature);
            TextView Humidity = FindViewById<TextView>(Resource.Id.humidity);
            ImageView Weatherimage = FindViewById<ImageView>(Resource.Id.weatherimage);

            Wind.Text = weatherWind.ToString() + " m/s";
            Temp.Text = Math.Round(currentTemp).ToString() + "°C";
            Humidity.Text = weatherHumidity.ToString() + "%";

            Bitmap imageBitmap = null;
            using (var webClient = new WebClient())
            {
                var imageBytes =
                    webClient.DownloadData(new Uri("http://openweathermap.org/img/w/" + icon.Trim() + ".png"));
                imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            }
            Weatherimage.SetImageBitmap(imageBitmap);
            Weatherimage.Visibility = ViewStates.Visible;
        }
    }
}