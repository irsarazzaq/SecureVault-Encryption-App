using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using SecureVault.Core;

namespace SecureVault.Algorithms
{
    public class AesCipher : CipherBase
    {
        public override byte[] Encrypt(byte[] data, string key)
        {
            Validate(data);

            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = new byte[32];
                Array.Copy(Encoding.UTF8.GetBytes(key), keyBytes, Math.Min(key.Length, 32));

                aes.Key = keyBytes;
                aes.IV = new byte[16];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                    }
                    return ms.ToArray();
                }
            }
        }

        public override byte[] Decrypt(byte[] data, string key)
        {
            Validate(data);

            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = new byte[32];
                Array.Copy(Encoding.UTF8.GetBytes(key), keyBytes, Math.Min(key.Length, 32));

                aes.Key = keyBytes;
                aes.IV = new byte[16];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                    }
                    return ms.ToArray();
                }
            }
        }
    }
}