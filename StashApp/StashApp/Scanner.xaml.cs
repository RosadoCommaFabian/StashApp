using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace StashApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Scanner : ZXingScannerPage
    {
        public Scanner()
        {
            InitializeComponent();

        }
        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //MySqlConnection conn;
                //MySqlCommand cmd = new MySqlCommand();
                //conn = DBUtilities.CreateConnection();
                //conn.Open();
                //if (DBUtilities.UpcExists(conn, result) == 1)
                //{
                //    await DisplayAlert("Scanning...", "Product found.", "OK");
                //    cmd.CommandText = $"SELECT name FROM Upc_Listings WHERE upc = '{result.Text}'";
                //    cmd.Connection = conn;
                //    string productName = (string)cmd.ExecuteScalar();
                //}
                //else
                //{
                //    await DisplayAlert("Scanning...", "Product not found.", "OK");
                //}
                //conn.Close();
                await DisplayAlert("Scanned result", result.Text, "OK");
            });
        }
    }
}