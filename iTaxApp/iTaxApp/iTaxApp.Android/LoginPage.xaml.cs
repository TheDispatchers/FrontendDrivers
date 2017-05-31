using System;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

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
        async void OnTest(object sender, EventArgs e)
        {
            User client;
            if (username.Text != null || password.Text != null)
            {
                client = new User(username.Text, password.Text);
                client.function = "login";
            } else
            {
                client = new User("user", "pass");
            }
            object obj = SynchronousSocketClient.StartClient("login", client);
            client = (User)obj;
            if (client.sessionKey.Length > 1)
            {
                await this.DisplayAlert("Test", "Connection established. Session key: "+ client.sessionKey, "Continue");
            }
            else
            {
                await this.DisplayAlert("Test", "Connection NOT established.", "Continue");
            }
        }
    }
}