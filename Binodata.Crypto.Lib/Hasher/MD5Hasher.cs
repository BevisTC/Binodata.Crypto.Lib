using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Binodata.Crypto.Lib.Hasher;

namespace Binodata.Crypto.Lib.Hasher
{
    public class MD5Hasher : IHasher
    {
        /// <summary>
        /// MD5 Hash
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Hash(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] bs = md5.ComputeHash(Encoding.Unicode.GetBytes(text));
                var sb = new StringBuilder();
                foreach (byte b in bs)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }

    
}
