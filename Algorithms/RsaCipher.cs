using System;
using System.Security.Cryptography;
using SecureVault.Core;

namespace SecureVault.Algorithms
{
    public class RsaCipher : CipherBase
    {
        private RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        public override byte[] Encrypt(byte[] data, string key)
        {
            return rsa.Encrypt(data, false);
        }

        public override byte[] Decrypt(byte[] data, string key)
        {
            return rsa.Decrypt(data, false);
        }
    }
}