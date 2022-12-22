using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StashApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : TabbedPage
    {
        protected SQLiteConnection stashDB;
        public Home()
        {
            InitializeComponent();

            //Create a stash that can be shared between Stash() and AddItems() pages
            var stash = InitializeStash();

            this.Children.Add(new Dashboard(stash, stashDB) { Title = "Dashboard" });
            this.Children.Add(new Stash(stash, stashDB) { Title = "Stash" });
            this.Children.Add(new AddItems(stash, stashDB) { Title = "Add Items" });
            this.Children.Add(new Settings() { Title = "Settings" });
            this.CurrentPage = this.Children[0];
        }
        public ObservableCollection<ItemBindable> InitializeStash()
        {
            var stash = new ObservableCollection<ItemBindable>
            {
                new ItemBindable {
                    Name = "Glico Pocky 2.46 oz.",
                    ExpirationDate = "12/17/2022",
                }
            };

            return stash;
        }
        public SQLiteConnection InitializeDB()
        {
            stashDB = DependencyService.Get<IDatabase>().ConnectToDB();
            stashDB.CreateTable<StashedProduct>();
            stashDB.CreateTable<BarcodeListings>();
            return stashDB;

        }
    }
}