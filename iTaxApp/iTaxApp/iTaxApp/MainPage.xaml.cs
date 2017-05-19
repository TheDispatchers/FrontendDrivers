using System;
using Xamarin.Forms;

namespace iTaxApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnCreateRide(object sender, EventArgs e)
        {

        }

        void OnHistory(object sender, EventArgs e)

        {

        }
        void OnSettings(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

    }
}