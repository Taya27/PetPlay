using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Common.Helpers
{
    public class JwtSettings
    {
        public Boolean ValidateLifetime { get; set; }
        public Boolean ValidateIssuer { get; set; }
        public String ValidIssuer { get; set; }
        public Boolean ValidateAudience { get; set; }
        public String ValidAudience { get; set; }
        public Boolean ValidateIssuerSigningKey { get; set; }
        public String IssuerSigningKey { get; set; }
        public Int32 TokenLifeTime { get; set; }
    }

}
