using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Models
{
    public class ToyModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string QRUrl { get; set; }
        public bool IsOwnedBySomeone { get; set; }

        public List<ConnectionModel> Connections { get; set; }
    }
}
