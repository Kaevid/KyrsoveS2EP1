using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace KyrsoveS2EP1
{
    class Hash
    {
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
