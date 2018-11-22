using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PetPlayMobile.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public LoginModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}