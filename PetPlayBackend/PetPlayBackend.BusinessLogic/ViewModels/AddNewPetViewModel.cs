using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.ViewModels
{
    public class AddNewPetViewModel
    {
        public string Nickname { get; set; }
        public string Breed { get; set; }
        public Guid UserId { get; set; }
    }
}
