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
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

	    async void OnSignUpButtonClicked(object sender, EventArgs e)
	    {
	        var signUpModel = new SignUpModel
	        {
	            Email = email.Text,
	            FirstName = fName.Text,
	            LastName = lName.Text,
	            Nickname = nick.Text,
	            Password = password.Text
	        };

            try
            {
                var auth = new AuthService();
                await auth.Register(signUpModel);

                messageLabel.Text = "You have been successfully registered";
            }
	        catch (Exception exception)
	        {
	            messageLabel.Text = exception.Message;
	        }
	    }
    }
}