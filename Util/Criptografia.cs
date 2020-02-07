using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Criptografia
    {
        public static string GerarChaveHashMD5(string entrada)
        {
            MD5 chaveHash = MD5.Create();

            byte[] hash = chaveHash.ComputeHash(Encoding.UTF8.GetBytes(entrada));

            StringBuilder construtorDaHash = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                construtorDaHash.Append(hash[i].ToString("x2"));
            }
            return construtorDaHash.ToString();
        }
    }
}
