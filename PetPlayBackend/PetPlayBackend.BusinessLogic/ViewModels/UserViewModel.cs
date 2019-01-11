using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Nickname { get; set; }
    }
}
