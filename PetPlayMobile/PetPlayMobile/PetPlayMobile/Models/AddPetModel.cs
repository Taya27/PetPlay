using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PetPlayMobile.Models
{
    public class AddPetModel
    {
        public string Nickname { get; set; }
        public string Breed { get; set; }

        public string Kind { get; set; }
        public Guid UserId { get; set; }
    }
}
