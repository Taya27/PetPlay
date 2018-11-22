using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PetPlayMobile.Services
{
    public class StorageService
    {
        public static void WriteValue(Context context, string key, string value)
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString(key, value);
            editor.Apply();
        }

        public static string GetValue(Context context, string key)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            return prefs.GetString(key, default(string));
        }
    }
}