using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PetPlayMobile.Models;
using PetPlayMobile.Services;

namespace PetPlayMobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        private EditText login;
        private EditText pass;
        private Button loginBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login);

            login = FindViewById<EditText>(Resource.Id.loginTxt);
            pass = FindViewById<EditText>(Resource.Id.passTxt);
            loginBtn = FindViewById<Button>(Resource.Id.loginBtn);

            loginBtn.Click += Login;
        }

        private async void Login(object o, EventArgs e)
        {
            try
            {
                loginBtn.Clickable = false;

                AuthService auth = new AuthService();
                var model = new LoginModel(login.Text, pass.Text);
                var result = await auth.Login(model);

                Services.StorageService.WriteValue(this, "userId", result.user_id.ToString());

                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
            finally
            {
                loginBtn.Clickable = true;
            }
        }
    }
}