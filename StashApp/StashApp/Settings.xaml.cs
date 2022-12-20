using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StashApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();

            BackgroundColor = Color.LightGreen;

            Label desc = new Label()
            {
                Margin = 10,
                Text = "This page will show a list of settings.",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            StackLayout stack = new StackLayout
            {
                Children =
                {
                    desc,
                }
            };
            this.Content = stack;
        }
    }
}