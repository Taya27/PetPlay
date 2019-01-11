using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Models;
using PetPlayMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetPlayMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage : ContentPage
	{
		public LogInPage ()
		{
			InitializeComponent();
		    usernameEntry.Text = "tayka";
		    passwordEntry.Text = "qwe123";
		}

	    async void OnSignUpButtonClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new SignUpPage());
	    }

	    async void OnLoginButtonClicked(object sender, EventArgs e)
	    {
	        var loginModel = new LoginModel
	        {
	            Login = usernameEntry.Text,
	            Password = passwordEntry.Text
	        };

	        try
	        {
                AuthService service = new AuthService();
	            var result = await service.Login(loginModel);

	            Application.Current.Properties[App.USER_ID] = result.user_id;
	            Application.Current.Properties[App.JWT] = result.auth_token;

                App.IsUserLoggedIn = true;
	            MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_MAIN_PAGE);
                await Navigation.PopAsync();
            }
	        catch (Exception exception)
	        {
	            messageLabel.Text = exception.Message;
            }

	    }
    }
}