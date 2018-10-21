using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.Domain.Models
{
    public class Access
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ToyId { get; set; }
        public Toy Toy { get; set; }

        public bool IsOwner { get; set; }
    }
}
