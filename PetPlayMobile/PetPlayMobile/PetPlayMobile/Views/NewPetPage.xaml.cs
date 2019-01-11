using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetPlayMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPetPage : ContentPage
	{
	    public AddPetModel Pet { get; set; }

		public NewPetPage()
		{
			InitializeComponent();
            Pet = new AddPetModel();

		    BindingContext = this;
		}

	    async void Save_Clicked(object sender, EventArgs e)
	    {
	        MessagingCenter.Send(this, "AddPet", Pet);
	        try
	        {
	            await Navigation.PopModalAsync();
            }
	        catch (Exception ex)
	        {

	        }
	        
	    }

	    async void Cancel_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PopModalAsync();
	    }
    }
}