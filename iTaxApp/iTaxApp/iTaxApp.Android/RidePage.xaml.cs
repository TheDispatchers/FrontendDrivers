using Plugin.Geolocator;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace iTaxApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RidePage : ContentPage
    {
        Geocoder geoCoder;
        Pin pin;
        string fromLatitude;
        string fromLongitude;
        string toLatitude;
        string toLongitude;
        public RidePage()
        {
            InitializeComponent();
            geoCoder = new Geocoder();
            customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
            customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
            customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
            customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
        }
        async void OnRefresh(object sender, EventArgs e)
        {
            reverseGeocodedOutputLabel.Text = "Searching..";
            MyMap.Pins.Clear();
            var locator = CrossGeolocator.Current;
            var pos = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            latitude.Text = "Latitude: " + pos.Latitude;
            longitude.Text = "Longitude: " + pos.Longitude;
            fromLatitude = pos.Latitude.ToString();
            fromLongitude = pos.Longitude.ToString();
            var position = new Position(pos.Latitude, pos.Longitude);
            pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Start location",
                Address = "Your taxi will pick you up here."
            };
            MyMap.Pins.Add(pin);
            customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
            customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
            customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
            customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));

            string[] myAddress = new string[3];
            {
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                int counter = 0;
                reverseGeocodedOutputLabel.Text = "";
                foreach (var address in possibleAddresses)
                {
                    if (counter < 1)
                    {
                        reverseGeocodedOutputLabel.Text += address;
                        location.Text = address;
                        counter++;
                    }
                }
            }
            if (destination.Text != null)
            {
                var addressToCode = destination.Text;
                var approximateLocations = await geoCoder.GetPositionsForAddressAsync(addressToCode);
                foreach (var destinationpos in approximateLocations)
                {
                    geocodedOutputLabel.Text = destinationpos.Latitude + ", " + destinationpos.Longitude + "\n";
                    toLatitude = destinationpos.Latitude.ToString();
                    toLongitude = destinationpos.Longitude.ToString();
                    pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = destinationpos,
                        Label = "Destination",
                        Address = "Your taxi will drop you off here."
                    };
                    MyMap.Pins.Add(pin);
                }
            }
        }
        public void OnExtras(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ExtrasPage());
        }
        void OnOrder(object sender, EventArgs e)
        {
            Ride ride;
            string sessionKey = Convert.ToString(App.Current.Properties["sessionKey"]);
            Console.WriteLine("Ses key: " + sessionKey);
            ride = new Ride(fromLatitude, fromLongitude, toLatitude, toLongitude, sessionKey);
            object obj = SynchronousSocketClient.StartClient("oderRide", ride);
            Navigation.PushAsync(new ExtrasPage());
        }

    }
}

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
