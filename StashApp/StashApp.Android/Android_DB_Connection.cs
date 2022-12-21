using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;
using System.IO; // Needed for the "Path" class reference.
using StashApp.Droid; // Needed for reference to "Android_DB_Connection" in the assembly.
using Xamarin.Forms; // Needed for the "Dependency" reference in assembly.

namespace StashApp.Droid
{
    class Android_DB_Connection : IDatabase
    {
        public Android_DB_Connection() { }

        public SQLiteConnection ConnectToDB()
        {
            var filename = "StashApp.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, filename);
            var connection = new SQLiteConnection(path);
            Console.WriteLine("DB Path = " + path);
            return connection;

        }
    }
}