using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Pickers;
using static Xamarin.Forms.Internals.Profile;
using System.Globalization;
using SQLite;

namespace StashApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard(ObservableCollection<ItemBindable> stash, SQLiteConnection db)
        {
            InitializeComponent();

            BackgroundColor = Color.LightGreen;
            Label desc = new Label()
            {
                Margin = 10,
                Text = "This page will display basic stats from the Stash page.",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Grid dashboardStats = new Grid()
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto},
                    new RowDefinition { Height = GridLength.Auto},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                },

            };
            dashboardStats.Children.Add(new Label
            {
                Text = $"0\nItems Stashed",
                FontSize = 24,
                Margin = 10,
            }, 0, 0);
            dashboardStats.Children.Add(new Label
            {
                Text = $"0\nItems Expired",
                FontSize = 24,
                Margin = 10,
                TextColor = Color.Red,
            }, 0, 1);
            dashboardStats.Children.Add(new Label
            {
                Text = $"0\nItems Fresh",
                FontSize = 24,
                Margin = 10,
                TextColor = Color.Green,
                FontAttributes = FontAttributes.Bold,
            }, 1, 0);
            dashboardStats.Children.Add(new Label
            {
                Text = $"0\nItems Soon to Expire",
                FontSize = 24,
                Margin = 10,
                TextColor = Color.Orange,
            }, 1, 1);
            Button updateButton = new Button
            {
                Text = "Update",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };
            updateButton.Clicked += async (sender, args) =>
            {
                
                await DisplayAlert("Updating...", "Dashboard updated!", "OK");
            };
            StackLayout stack = new StackLayout
            {
                Children =
                {
                    desc,
                    dashboardStats,
                    updateButton,
                }
            };
            this.Content = stack;
        }
    }
}