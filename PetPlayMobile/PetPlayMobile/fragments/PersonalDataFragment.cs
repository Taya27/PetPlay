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

namespace PetPlayMobile.fragments
{
    public class PersonalDataFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            HasOptionsMenu = true;
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.PersonalData, null);

            return view;
        }

        private async Task Init(View view)
        {
            var user = await GetCurrentUser();
            view.FindViewById<TextView>(Resource.Id.textView1).Text = $"{user.FirstName} {user.LastName}";
            view.FindViewById<TextView>(Resource.Id.textView2).Text = $"{user.Email}";
            view.FindViewById<TextView>(Resource.Id.textView3).Text = $"@{user.Nickname}";
        }

        private async Task<UserModel> GetCurrentUser()
        {
            var userId = StorageService.GetValue(this.Activity, "userId");
            var service = new UserService();

            var user = await service.GetUser(Guid.Parse(userId));

            return user;
        }

        public async override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            await Init(view);
            base.OnViewCreated(view, savedInstanceState);
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.menu_main, menu);
        }
    }
}