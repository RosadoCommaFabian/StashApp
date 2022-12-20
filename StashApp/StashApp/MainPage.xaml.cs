using StashApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StashApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BackgroundColor = Color.LightGreen;
            Padding = 25;

            Label stashLabel = new Label()
            {
                Text = "Stash",
                FontSize = 72,
                TextColor = Color.DarkOliveGreen,
                FontFamily = "Beef",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Button logInButton = new Button()
            {
                Text = "Log In",
                HorizontalOptions = LayoutOptions.Center,
            };
            logInButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Home());
            };
            Label desc = new Label()
            {
                Margin = 10,
                FontSize = 18,
                TextColor = Color.DarkOliveGreen,
                Text = "Welcome to the Stash app! Stash keeps track of all food items at home, and reminds you when they are close to expiring.",
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            StackLayout stack = new StackLayout
            {
                Children =
                {
                    stashLabel,
                    logInButton,
                    desc,
                }
            };
            this.Content = stack;

        }
    }
}

