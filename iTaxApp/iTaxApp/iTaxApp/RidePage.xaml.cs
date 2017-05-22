using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace iTaxApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RidePage : ContentPage
	{
		public RidePage ()
		{
			InitializeComponent ();
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
        void OnExtras(object sender, EventArgs e)
        {

        }
        void OnOrder(object sender, EventArgs e)
        {

        }
    }
}