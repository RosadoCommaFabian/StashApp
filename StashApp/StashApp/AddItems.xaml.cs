using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZXing.Net.Mobile.Forms;
using MySqlConnector;
using System.Collections.ObjectModel;
using Syncfusion.XForms.Pickers;

namespace StashApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItems : ContentPage
    {
        public AddItems(ObservableCollection<ItemBindable> stash)
        {
            InitializeComponent();

            BackgroundColor = Color.LightGreen;

            Label desc = new Label()
            {
                Margin = 10,
                Text = "This page allow a person to use their camera to scan a QR code. Items can be added from this page.",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Button addManually = new Button
            {
                Text = "Add Item Manually",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };
            Entry stashItem = new Entry()
            {
                Placeholder = "Stash Item Name",
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Text
            };
            Label expirationLabel = new Label()
            {
                Margin = 10,
                Text = "Expiration Date",
                FontSize = 24,
            };
            DatePicker expirationDate = new DatePicker
            {
                Format = DateFormat.yyyy_MM_dd.ToString(),
                VerticalOptions = LayoutOptions.Center,
            };
            addManually.Clicked += async (sender, args) =>
            {
                try
                {
                    stash.Add(new ItemBindable { Name = stashItem.Text.ToString(), ExpirationDate = expirationDate.Date.ToShortDateString() });
                    await DisplayAlert("Stashing...", "Product added", "OK");
                    stashItem.Text = null;
                }
                catch
                {
                    await DisplayAlert("ERROR", "Input text missing for stash item.", "OK");
                }
            };
            Button scanQRButton = new Button
            {
                Text = "Scan QR Code",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };
            scanQRButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Scanner());
            };
            StackLayout stack = new StackLayout
            {
                Children =
                {
                    desc,
                    scanQRButton,
                    addManually,
                    stashItem,
                    expirationLabel,
                    expirationDate,
                }
            };
            this.Content = stack;
        }
    }
}