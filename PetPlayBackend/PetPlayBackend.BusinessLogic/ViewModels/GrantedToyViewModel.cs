using System;
using System.Collections.Generic;
using System.Text;
using PetPlayBackend.BusinessLogic.Models;

namespace PetPlayBackend.BusinessLogic.ViewModels
{
    public class GrantedToyViewModel
    {
        public ToyModel Toy { get; set; }
        public UserModel User { get; set; }
    }
}
