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
    public partial class ExtrasPage : ContentPage
    {
        public ExtrasPage()
        {
            InitializeComponent();
        }


        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }
}