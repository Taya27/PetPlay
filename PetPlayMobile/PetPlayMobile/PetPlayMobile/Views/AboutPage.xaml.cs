using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetPlayMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            App.Current.Properties.Clear();
            App.IsUserLoggedIn = false;
            App.Current.MainPage = new NavigationPage(new LogInPage());
        }
    }
}