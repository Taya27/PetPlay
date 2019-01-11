using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Models;
using PetPlayMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetPlayMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PetDetailPage : ContentPage
	{
	    private PetDetailViewModel viewModel;

		public PetDetailPage (PetDetailViewModel model)
		{
			InitializeComponent();

		    BindingContext = viewModel = model;
		}

	    async void DeletePet_Clicked(object sender, EventArgs e)
	    {
	        MessagingCenter.Send(this, "DeletePet", viewModel.Pet);
	        await this.Navigation.PopAsync();
	    }

        public PetDetailPage()
	    {
	        InitializeComponent();

	        var model = new PetModel
	        {
                Breed = "Normal",
                Kind = "Cat",
                Nickname = "Asya"
	        };

            viewModel = new PetDetailViewModel(model);
	        BindingContext = this.viewModel;
	    }
	}
}