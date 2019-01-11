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
	public partial class PetsPage : ContentPage
	{
	    private PetsViewModel viewModel;

		public PetsPage ()
		{
			InitializeComponent();

		    BindingContext = viewModel = new PetsViewModel();
		}

	    async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
	    {
            var item = args.SelectedItem as PetModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new PetDetailPage(new PetDetailViewModel(item)));

            // Manually deselect item.
            PetsListView.SelectedItem = null;
        }

	    async void AddItem_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new NavigationPage(new NewPetPage()));
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        if (viewModel.Pets.Count == 0)
	            viewModel.LoadPetsCommand.Execute(null);
	    }
    }
}