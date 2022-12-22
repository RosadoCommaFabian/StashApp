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
        public DashBindable itemsStashed = new DashBindable();
        public DashBindable itemsExpired = new DashBindable();
        public DashBindable itemsFresh = new DashBindable();
        public DashBindable itemsSoon = new DashBindable();

        public Dashboard(ObservableCollection<ItemBindable> stash, SQLiteConnection db)
        {
            InitializeComponent();

            itemsStashed.Counter = "0";
            itemsExpired.Counter = "0";
            itemsFresh.Counter = "0";
            itemsSoon.Counter = "0";

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
                Text = $"{itemsStashed.Counter}\nItems Stashed",
                FontSize = 24,
                Margin = 10,
            }, 0, 0);
            dashboardStats.Children.Add(new Label
            {
                Text = $"{itemsExpired.Counter}\nItems Expired",
                FontSize = 24,
                Margin = 10,
                TextColor = Color.Red,
            }, 0, 1);
            dashboardStats.Children.Add(new Label
            {
                Text = $"{itemsFresh.Counter}\nItems Fresh",
                FontSize = 24,
                Margin = 10,
                TextColor = Color.Green,
                FontAttributes = FontAttributes.Bold,
            }, 1, 0);
            dashboardStats.Children.Add(new Label
            {
                Text = $"{itemsSoon.Counter}\nItems Soon to Expire",
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
                foreach (ItemBindable product in stash)
                {
                    this.BindingContext = itemsStashed;
                    itemsStashed.Counter = (Int32.Parse(itemsStashed.Counter) + 1).ToString();
                    //Expiration Date - Current Date = x number of days until it expires
                    int daysUntilExpire = ((DateTime.Parse(product.ExpirationDate) - DateTime.Now).Days);
                    if (daysUntilExpire > 14)
                    {
                        this.BindingContext = itemsFresh;
                        itemsFresh.Counter = (Int32.Parse(itemsFresh.Counter) + 1).ToString();
                    }
                    else if (daysUntilExpire <= 14 && daysUntilExpire > 0)
                    {
                        this.BindingContext = itemsSoon;
                        itemsSoon.Counter = (Int32.Parse(itemsSoon.Counter) + 1).ToString();
                    }
                    else
                    {
                        this.BindingContext = itemsExpired;
                        itemsExpired.Counter = (Int32.Parse(itemsExpired.Counter) + 1).ToString();
                    }
                }
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