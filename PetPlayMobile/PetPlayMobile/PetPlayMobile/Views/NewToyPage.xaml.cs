using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Models;
using PetPlayMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;

namespace PetPlayMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewToyPage : ContentPage
	{
        public AddNewToyModel Toy { get; set; }

		public NewToyPage()
		{
		    InitializeComponent();

		    Toy = new AddNewToyModel();

            BindingContext = this;
		}

	    private async void btnScan_Clicked(object sender, EventArgs e)
	    {
	        try
	        {
	            var scanner = new MobileBarcodeScanner();
	            var result = await scanner.Scan();

	            if (result != null) Toy.ToyId = result.Text;
	        }
	        catch (Exception ex)
	        {
	            messageLabel.Text = ex.Message;
	            throw;
	        }
	    }

        async void Save_Clicked(object sender, EventArgs e)
	    {
	        Toy.Callback = async ex =>
	        {
	            if (ex.GetType() == typeof(Exception))
	            {
	                Device.BeginInvokeOnMainThread(() => {
	                    DisplayAlert("Error", ((Exception)ex).Message, "OK");
	                });
                }
                else await Navigation.PopModalAsync(); 
	        };
            MessagingCenter.Send(this, "AddToy", Toy);
	    }

	    async void Cancel_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PopModalAsync();
	    }
    }
}