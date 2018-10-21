﻿using System;
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

        public virtual List<Access> Accesses { get; set; }

        public User()
        {
            Accesses = new List<Access>();
        }
    }
}
