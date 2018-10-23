using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Models
{
    public class AccessModel
    {
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid ToyId { get; set; }
        public ToyModel Toy { get; set; }

        public bool IsOwner { get; set; }
    }
}
