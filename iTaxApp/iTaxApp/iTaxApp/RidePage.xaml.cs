using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace iTaxApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RidePage : ContentPage
    {

        Geocoder geoCoder;

        public RidePage()
        {
            InitializeComponent();
            geoCoder = new Geocoder();


            /*
            var position = new Position(54.9134468, 9.7827599); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Destination",
                Address = "Order a taxi to this location."
            };
            MyMap.Pins.Add(pin);
            /*customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
            customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
            customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
            customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
            */

        }


        async void OnRefresh(object sender, EventArgs e)
        {
            Pin pin;
            MyMap.Pins.Clear();
            var locator = CrossGeolocator.Current;
            var pos = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            Console.WriteLine("Position Status: {0}", pos.Timestamp);
            Console.WriteLine("Position Latitude: {0}", pos.Latitude);
            Console.WriteLine("Position Longitude: {0}", pos.Longitude);
            location.Text = pos.Latitude + ", " + pos.Longitude;
            latitude.Text = "Latitude: " + pos.Latitude;
            longitude.Text = "Longitude: " + pos.Longitude;

            var position = new Position(pos.Latitude, pos.Longitude);
            pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Location",
                Address = "Your taxi will arrive to this place."
            };
            MyMap.Pins.Add(pin);
            string[] myAddress = new string[3];
            {
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                int counter = 0;
               
                foreach (var address in possibleAddresses)
                {
                    if (counter < 1)
                    {
                        reverseGeocodedOutputLabel.Text += address + "\n";
                        Console.WriteLine("Address:: " + address);
                        counter++;
                    }
                    
                }

            }
        }
        public void OnExtras(object sender, EventArgs e)
        {

        }
        void OnOrder(object sender, EventArgs e)
        {

        }

    }
}