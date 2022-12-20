using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StashApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Uses hierarchical navigation
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
