using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayMobile.Models
{
    public class LoginResultModel
    {
        public string auth_token { get; set; }
        public Guid user_id { get; set; }
    }
}
