using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.ViewModels
{
    public class AccessViewModel
    {
        public Guid UserId { get; set; }

        public Guid ToyId { get; set; }

        public bool IsOwner { get; set; }
    }
}
