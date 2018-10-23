using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }

        public List<AccessModel> Accesses { get; set; }
        public List<PetModel> Pets { get; set; }
    }
}
