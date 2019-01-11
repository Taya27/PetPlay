using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayMobile.Models
{
    public class PetModel
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Breed { get; set; }

        public string Kind { get; set; }
    }
}
