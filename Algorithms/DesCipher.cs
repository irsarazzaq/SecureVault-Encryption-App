using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using SecureVault.Core;

namespace SecureVault.Algorithms
{
    public class DesCipher : CipherBase
    {
        public override byte[] Encrypt(byte[] data, string key)
        {
            Validate(data);

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] keyBytes = new byte[8];
                Array.Copy(Encoding.UTF8.GetBytes(key), keyBytes, Math.Min(key.Length, 8));

                des.Key = keyBytes;
                des.IV = new byte[8];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
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

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] keyBytes = new byte[8];
                Array.Copy(Encoding.UTF8.GetBytes(key), keyBytes, Math.Min(key.Length, 8));

                des.Key = keyBytes;
                des.IV = new byte[8];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
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