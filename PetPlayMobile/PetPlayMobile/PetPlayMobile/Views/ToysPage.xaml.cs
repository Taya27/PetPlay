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
	public partial class ToysPage : ContentPage
	{
	    private ToysViewModel viewModel;

        public ToysPage ()
		{
			InitializeComponent();

		    BindingContext = viewModel = new ToysViewModel();
		}

	    async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
	    {
            var item = args.SelectedItem as ToyModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new ToyControl());

            // Manually deselect item.
            PetsListView.SelectedItem = null;
        }

	    async void AddItem_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new NavigationPage(new NewToyPage()));
	    }

	    protected override void OnAppearing()
	    {
            base.OnAppearing();

            if (viewModel.Toys.Count == 0)
                viewModel.LoadToysCommand.Execute(null);
        }
    }
}