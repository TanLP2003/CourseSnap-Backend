using JwtSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Extensions
{
    public static class GetRsaExtensions
    {
        public async static Task<RSA> UseKeyFromFile(string path)
        {
            var key = await File.ReadAllTextAsync(path);
            var rsa = RSA.Create();
            rsa.FromXmlString(key);
            return rsa;
        }
    }
}
