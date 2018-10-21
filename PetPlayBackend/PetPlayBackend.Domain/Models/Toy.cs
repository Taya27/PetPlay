using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.Domain.Models
{
    public class Toy
    {
        public Guid Id { get; set; }
        public string Model { get; set; }

        public virtual List<Access> Accesses { get; set; }
        public Toy()
        {
            Accesses = new List<Access>();
        }
    }
}
