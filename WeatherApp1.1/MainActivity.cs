using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;

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
           

            var Button = FindViewById<Button>(Resource.Id.button1);
            Button.Click += Button_Click;
        }
        private async void Button_Click(object sender, System.EventArgs e)
        {
            var cityname_ = FindViewById<EditText>(Resource.Id.cityname);
            string city = cityname_.Text.ToString();
            queryurl = "https://openweathermap.org/data/2.5/weather?q=" + city + "&appid=b6907d289e10d714a6e88b30761fae22";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(queryurl);
            HttpContent content = response.Content;
            dynamic result = await content.ReadAsStringAsync();
        


            TextView Wind = FindViewById<TextView>(Resource.Id.wind);
            Wind.Text = result;

        }
    }
}