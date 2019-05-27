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
        //static string city = "Tallinn";
        //static EditText cityname_ = (EditText)FindViewById(Resource.Id.cityname);
        //static string city = cityname_.getText().toString();
        string queryurl;
        static string result = "result error";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           

            var Button = FindViewById<Button>(Resource.Id.button1);
            Button.Click += Button_Click;

            //TextView Ilmainfo = FindViewById<TextView>(Resource.Id.ilmainfo);
            //Ilmainfo.Text = queryurl;

        }
        private async void Button_Click(object sender, System.EventArgs e)
        {
            var cityname_ = FindViewById<EditText>(Resource.Id.cityname);
            string city = cityname_.Text.ToString();
            queryurl = "https://openweathermap.org/data/2.5/weather?q=" + city + "&appid=b6907d289e10d714a6e88b30761fae22";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(queryurl);
            HttpContent content = response.Content;
            string result = await content.ReadAsStringAsync();
            TextView Ilmainfo = FindViewById<TextView>(Resource.Id.ilmainfo);
            Ilmainfo.Text = result;
            //return result;

        }
        //public static async Task<string> Data(string apiurl="https://openweathermap.org/data/2.5/weather?q=Tallinn,est&appid=b6907d289e10d714a6e88b30761fae22")
        //{
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync(apiurl);
        //    HttpContent content = response.Content;
        //    string result = await content.ReadAsStringAsync();
        //    return result;
           

        //}

    }
}