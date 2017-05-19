using System;
using Xamarin.Forms;

namespace iTaxApp
{
    public partial class LoginPage : ContentPage
    {
        bool loggedin;

        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLogin(object sender, EventArgs e)
        {
            if (username.Text != null || password.Text != null)
            {
                loggedin = Core.LoginSystem.Login(username.Text, password.Text);
                if (loggedin)
                {
                    await this.DisplayAlert("Login", "User " + username.Text + " sucessfully logged in.", "Continue");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await this.DisplayAlert("Login", "User " + username.Text + " NOT logged in. Wrong username or password.", "Try again");
                }
                /*  translatedNumber = Core.iTaxAppTranslator.ToNumber(phoneNumberText.Text);
                  if (!string.IsNullOrWhiteSpace(translatedNumber))
                  {
                      callButton.IsEnabled = true;
                      callButton.Text = "Call " + translatedNumber;
                  }
                  else
                  {
                      callButton.IsEnabled = false;
                      callButton.Text = "Call";
                  }*/
            }

        }

        async void OnRegister(object sender, EventArgs e)

        {
            if (await this.DisplayAlert(
                    "Register",
                    "Would you like to create a new account?",
                    "Yes",
                    "No"))
            {
                await Navigation.PushAsync(new RegisterPage());
            }
        }
    }
}