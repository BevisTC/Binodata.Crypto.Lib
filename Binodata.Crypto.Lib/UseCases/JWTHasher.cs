using Jose;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binodata.Crypto.Lib.UseCases
{
    public class JWTHasher
    {
        /// <summary>
        /// 取得JWT
        /// </summary>
        /// <param name="reqStr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJWTValue(string reqStr, string key)
        {
            string token = JWT.Encode(reqStr, Encoding.Unicode.GetBytes(key), JwsAlgorithm.HS256);

            return token;
        }
    }
}
