using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayMobile.Models
{
    public class AccessModel
    {
        public string UserId { get; set; }
        public UserModel User { get; set; }

        public string ToyId { get; set; }
        public ToyModel Toy { get; set; }

        public bool IsOwner { get; set; }
    }
}
