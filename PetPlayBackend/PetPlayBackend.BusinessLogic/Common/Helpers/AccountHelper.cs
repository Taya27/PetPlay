using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Common.Helpers
{
    public class AccountHelper
    {
        public static string GetPasswordHash(string password)
        {
            using (var md5 = MD5.Create())
            {
                var resultBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

                return string.Join(string.Empty, resultBytes.Select(x => x.ToString("X02")));
            }
        }

    }
}
