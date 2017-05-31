using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iTaxApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            var carTypesList = new List<string>();
            carTypesList.Add("Any");
            carTypesList.Add("Truck (Pick-Up)");
            carTypesList.Add("Sedan");
            carTypesList.Add("Van");
            carTypesList.Add("Hybrid/Electric");
            carTypesList.Add("Convertible");
            carTypesList.Add("Wagon");
            cartype.ItemsSource = carTypesList;
        }
        void OnRegister(object sender, EventArgs e)
        {

        }

    }
}