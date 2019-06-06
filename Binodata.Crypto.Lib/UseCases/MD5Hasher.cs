using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Binodata.Crypto.Lib.UseCases
{
    public class MD5Hasher
    {
        /// <summary>
        /// MD5 Hash
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Hash(string text)
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
