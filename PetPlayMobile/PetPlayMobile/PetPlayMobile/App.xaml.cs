using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetPlayMobile.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PetPlayMobile
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static string EVENT_LAUNCH_MAIN_PAGE = "EVENT_LAUNCH_MAIN_PAGE";
        public static string EVENT_LAUNCH_LOGIN_PAGE = "EVENT_LAUNCH_LOGIN_PAGE";
        public static string USER_ID = "IdshkaUzverya";
        public static string JWT = "JisinBebTocken";

        public App()
        {
            InitializeComponent();

            if (IsUserLoggedIn || Current.Properties.ContainsKey(JWT))
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new LogInPage());
            }

            MessagingCenter.Subscribe<object>(this, EVENT_LAUNCH_MAIN_PAGE, SetMainPageAsRootPage);
            MessagingCenter.Subscribe<object>(this, EVENT_LAUNCH_LOGIN_PAGE, SetLoginPageAsRootPage);
        }

        private void SetMainPageAsRootPage(object sender)
        {
            MainPage = new MainPage();
        }

        private void SetLoginPageAsRootPage(object sender)
        {
            MainPage = new NavigationPage(new LogInPage());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
