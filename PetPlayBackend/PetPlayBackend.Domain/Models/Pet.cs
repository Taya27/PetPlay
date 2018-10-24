using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.Domain.Models
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Breed { get; set; }
        public string Kind { get; set; }

        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
