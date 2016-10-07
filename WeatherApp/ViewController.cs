using System;
using System.Linq;
using System.Net.Http;
using UIKit;
using CoreLocation;
using MapKit;
using System.Xml.Linq;

namespace WeatherApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            MyMap.RegionChanged += MyMap_RegionChanged;

        }

        private void MyMap_RegionChanged(object sender, MKMapViewChangeEventArgs e)
        {
            GetWeather(MyMap.CenterCoordinate);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        async void GetWeather(CLLocationCoordinate2D location)
        {
            string serviceUrl =
                $"http://api.openweathermap.org/data/2.5/weather?lat={location.Latitude}&lon={location.Longitude}&appid=aa0c788a0a6debea2c5da1d89d7f79ea&mode=xml&units=metric";

            var client = new HttpClient();
            var response = await client.GetStringAsync(serviceUrl);

            var data = XElement.Parse(response);
            string temperature = data.Elements("temperature").FirstOrDefault()?
                .Attribute("value")?.Value;

            string city = data.Elements("city").FirstOrDefault()?
                .Attribute("name")?.Value;

            Description.Text = $"City {city}, {temperature}°C";
        }
    }
}