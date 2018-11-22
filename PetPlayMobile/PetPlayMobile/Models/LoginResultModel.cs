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
    public class LoginResultModel
    {
        public string auth_token { get; set; }
        public Guid user_id { get; set; }
    }
}