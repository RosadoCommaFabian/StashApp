using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using System.Data;

namespace StashApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stash : ContentPage
    {
        public Stash(ObservableCollection<ItemBindable> stash)
        {
            InitializeComponent();

            BackgroundColor = Color.LightGreen;

            MySqlConnection conn;

            Label desc = new Label()
            {
                Margin = 10,
                Text = "This page will display all of the items in the Stash. These items can be deleted and edited from this page.",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            var listView = new ListView();
            listView.ItemsSource = stash;
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ExpirationDate"); ;
            listView.VerticalOptions = LayoutOptions.StartAndExpand;
            listView.ItemTapped += async (sender, e) =>
            {
                ItemBindable item = (ItemBindable)e.Item;
                var response = await DisplayAlert("Editor", "Do you want to modify " + item.Name.ToString() + "?", "OK", "Edit");
                if (response == false) //If Edit is selected
                {
                    item.Name = await DisplayPromptAsync("Name", "Enter a new product name: ");
                    item.ExpirationDate = await DisplayPromptAsync("Date of Expiration", "When will it expire: ");
                }
                ((ListView)sender).SelectedItem = null;
            };
            Button buttonDelete = new Button
            {
                Text = "Delete Row",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };
            buttonDelete.Clicked += async (sender, args) =>
            {
                stash.RemoveAt(0);
                await DisplayAlert("Delete", "Item has been deleted.", "OK");
            };
            Button syncButton = new Button()
            {
                Text = "Sync to Cloud",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };
            syncButton.Clicked += async (sender, args) =>
            {
                conn = DBUtilities.CreateConnection();
                conn.Open();
                foreach (ItemBindable product in stash)
                {
                    DBUtilities.SyncStashItem(conn, product.Name, product.ExpirationDate);
                }
                conn.Close();
                await DisplayAlert("Syncing...", "Stash has been synced with DB.", "OK");
            };
            StackLayout stack = new StackLayout
            {
                Children =
                {
                    desc,
                    listView,
                    buttonDelete,
                    syncButton,
                }
            };
            this.Content = stack;
        }
    }
}