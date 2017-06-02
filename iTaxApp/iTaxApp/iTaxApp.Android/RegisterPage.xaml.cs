﻿using iTaxApp;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]

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
        async void OnRegister(object sender, EventArgs e)
        {
            if (email.Text != null)
            {
                if (username.Text != null)
                {
                    if (password.Text != null)
                    {
                        if (firstname.Text != null)
                        {
                            if (lastname.Text != null)
                            {
                                if (password.Text.Equals(confirmpassword.Text))
                                {
                                    NewUser newUser = new NewUser(email.Text, username.Text, Core.LoginSystem.CalculateMD5Hash(password.Text), firstname.Text, lastname.Text, cartype.SelectedIndex+1);
                                    newUser.function = "register";
                                    object obj = SynchronousSocketClient.StartClient("register", newUser);
                                    newUser = (NewUser)obj;
                                    if (newUser.response.Equals("success", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DependencyService.Get<IMessage>().ShortAlert("Server says: " + newUser.response);
                                        await this.DisplayAlert("Register", "User " + newUser.username + " created. You should get a confirmation e-mail shortly.", "OK");
                                        await Navigation.PopAsync();
                                        
                                    }
                                    else
                                    {
                                        DependencyService.Get<IMessage>().ShortAlert("Server says: " + newUser.response);
                                    }
                                }
                                else
                                {
                                    DependencyService.Get<IMessage>().ShortAlert("Please make sure your passwords match.");
                                }
                            }
                            else
                            {
                                DependencyService.Get<IMessage>().ShortAlert("Please enter your last name.");
                            }
                        }
                        else
                        {
                            DependencyService.Get<IMessage>().ShortAlert("Please enter your first name.");
                        }
                    }
                    else
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Please enter a password.");
                    }
                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert("Please enter a ID.");
                }
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("Please enter your e-mail.");
            }
        }
    }
}