using System;
using System.Collections.Generic;
using System.Text;
using PetPlayMobile.Models;

namespace PetPlayMobile.ViewModels
{
    public class PetDetailViewModel : BaseViewModel
    {
        public PetModel Pet { get; set; }

        public PetDetailViewModel(PetModel pet = null)
        {
            Title = $"{pet?.Kind} {pet?.Nickname}";
            Pet = pet;
        }
    }
}
