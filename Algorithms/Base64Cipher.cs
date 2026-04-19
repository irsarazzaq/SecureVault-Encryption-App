using System;
using System.Text;
using SecureVault.Core;

namespace SecureVault.Algorithms
{
    public class Base64Cipher : CipherBase
    {
        public override byte[] Encrypt(byte[] data, string key)
        {
            Validate(data);
            string base64 = Convert.ToBase64String(data);
            return Encoding.UTF8.GetBytes(base64);
        }

        public override byte[] Decrypt(byte[] data, string key)
        {
            Validate(data);
            string text = Encoding.UTF8.GetString(data);
            return Convert.FromBase64String(text);
        }
    }
}