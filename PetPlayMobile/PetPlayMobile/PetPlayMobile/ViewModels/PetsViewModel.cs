using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Models;
using PetPlayMobile.Services;
using PetPlayMobile.Views;
using Xamarin.Forms;

namespace PetPlayMobile.ViewModels
{
    public class PetsViewModel : BaseViewModel
    {
        public ObservableCollection<PetModel> Pets { get; set; }
        public Command LoadPetsCommand { get; set; }

        PetService _petService = new PetService();

        public PetsViewModel()
        {
            Title = "Your pets";
            Pets = new ObservableCollection<PetModel>();
            LoadPetsCommand = new Command(async () => await ExecuteLoadPetsCommand());

            MessagingCenter.Subscribe<NewPetPage, AddPetModel>(this, "AddPet", async (obj, item) =>
            {
                try
                {
                    var newItem = item as AddPetModel;
                    newItem.UserId = Guid.Parse(Application.Current.Properties[App.USER_ID].ToString());

                    var result = await _petService.AddNewPet(newItem);

                    LoadPetsCommand.Execute(null);
                }
                catch (Exception ex)
                {

                }
            });

            MessagingCenter.Subscribe<PetDetailPage, PetModel>(this, "DeletePet", async (obj, pet) =>
            {
                var result = await _petService.DeletePet(pet.Id);
                Pets.Remove(Pets.Single(x => x.Id == result.Id));
            });
        }

        async Task ExecuteLoadPetsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Pets.Clear();
                var pets = await _petService.GetUserPets(Application.Current.Properties[App.USER_ID].ToString());
                foreach (var pet in pets)
                {
                    Pets.Add(pet);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
