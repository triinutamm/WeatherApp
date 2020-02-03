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
            //5 day forecast
            var forecastButton = FindViewById<Button>(Resource.Id.forecastBtn);
            Button.Click += Button_Click;
            forecastButton.Click += ForecastButton_Click;
        }
        //Kui klikin 5 day forecast, siis läheb teise vaatesse 
        private void ForecastButton_Click(object sender, EventArgs e)
        {
            var secondActivity = new Intent(this, typeof(ForecastActivity));
            StartActivity(secondActivity);
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
            // Tee TextViewe juurde ja muuda mu tehtud variabled nendeks textviewideks
            var currentTemp = data.main.temp;
            var weatherTemperatureMin = data.main.temp_min;
            var weatherTemperatureMax = data.main.temp_max;
            var weatherWind = data.wind.speed;
            var weatherHumidity = data.main.humidity;
            var weatherVisibility = data.weather.FirstOrDefault().main;


            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var weatherSunrise = time.AddSeconds(data.sys.sunrise);
            var weatherSunset = time.AddSeconds(data.sys.sunset);
            var icon = data.weather.FirstOrDefault().icon;

            TextView Wind = FindViewById<TextView>(Resource.Id.wind);
            TextView MaxMin = FindViewById<TextView>(Resource.Id.temperature);
            TextView Humidity = FindViewById<TextView>(Resource.Id.humidity);
            //TextView Wind = FindViewById<TextView>(Resource.Id.wind);
            ImageView Weatherimage = FindViewById<ImageView>(Resource.Id.weatherimage);

            Wind.Text = weatherWind.ToString() + " m/s";
            MaxMin.Text = weatherTemperatureMin.ToString() + "/" + weatherTemperatureMax;
            Humidity.Text = weatherHumidity.ToString() + "%";


            Bitmap imageBitmap = null;
            using (var webClient = new WebClient())
            {
                var imageBytes =
                    webClient.DownloadData(new Uri("http://openweathermap.org/img/w/" + icon.Trim() + ".png"));
                imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            }
            Weatherimage.SetImageBitmap(imageBitmap);

        }
    }
}