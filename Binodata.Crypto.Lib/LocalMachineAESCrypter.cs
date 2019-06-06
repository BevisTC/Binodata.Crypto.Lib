using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Binodata.Crypto.Lib
{
    public class LocalMachineAESCrypter : IAESCrypter
    {

        private string Key;
        private string IV;

        public LocalMachineAESCrypter()
        {

        }

        public LocalMachineAESCrypter(string key, string iv)
        {
            this.Key = key;
            this.IV = iv;
        }

        public void SetKey(string key) {
            this.Key = key;

        }


        public void SetIV(string iv) {
            this.IV = iv;
        }

        public string Decrypt(string cypherText)
        {
            SymmetricAlgorithm symmetricAlgorithm = new AesCryptoServiceProvider();

            symmetricAlgorithm.Key = Encoding.ASCII.GetBytes(this.Key);
            symmetricAlgorithm.IV =  Encoding.ASCII.GetBytes(this.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] dataByteArray = Convert.FromBase64String(cypherText);
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        public string Encrypt(string plainText)
        {
            SymmetricAlgorithm symmetricAlgorithm = new AesCryptoServiceProvider();

            symmetricAlgorithm.Key = Encoding.ASCII.GetBytes(this.Key);
            symmetricAlgorithm.IV = Encoding.ASCII.GetBytes(this.IV);
            symmetricAlgorithm.Padding = PaddingMode.None;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] dataByteArray = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
