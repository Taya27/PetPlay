using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public virtual List<Access> Accesses { get; set; }
        public virtual List<Pet> Pets { get; set; }

        public virtual List<Connection> Connections { get; set; }

        public User()
        {
            Connections = new List<Connection>();
            Accesses = new List<Access>();
            Pets = new List<Pet>();
        }
    }
}
