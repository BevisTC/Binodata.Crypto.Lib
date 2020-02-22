using System;
using System.Collections.Generic;
using System.Text;

namespace Binodata.Crypto.Lib
{
    public interface IAESCrypter
    {
        string Encrypt(string plainText);

        string Decrypt(string cypherText);
        
        void SetKey(string key);

        void SetIV(string iv);
    }
}
