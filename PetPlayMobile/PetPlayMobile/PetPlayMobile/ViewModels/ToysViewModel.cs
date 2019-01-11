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
    public class ToysViewModel : BaseViewModel
    {
        public ObservableCollection<ToyModel> Toys { get; set; }
        public Command LoadToysCommand { get; set; }

        AccessService service = new AccessService();

        public ToysViewModel()
        {
            Title = "Your toys";
            Toys = new ObservableCollection<ToyModel>();
            LoadToysCommand = new Command(async () => await ExecuteLoadToysCommand());

            MessagingCenter.Subscribe<NewToyPage, AddNewToyModel>(this, "AddToy", async (obj, item) =>
            {
                var newItem = item as AddNewToyModel;
                newItem.UserId = Application.Current.Properties[App.USER_ID].ToString();
                newItem.IsOwner = true;
                try
                {
                    await service.AddAccess(newItem);
                }
                catch (Exception ex)
                {
                    item.Callback(ex);
                    return;
                }

                Toys.Clear();
                LoadToysCommand.Execute(null);

                item.Callback("Success");
            });
        }

        async Task ExecuteLoadToysCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Toys.Clear();
                var accesses = await service.GetUserAccesses(Application.Current.Properties[App.USER_ID].ToString());
                var toys = accesses.Where(x => x.IsOwner).Select(x => x.Toy);

                foreach (var toy in toys)
                {
                    Toys.Add(toy);
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
