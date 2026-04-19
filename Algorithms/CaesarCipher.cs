using System;
using SecureVault.Core;

namespace SecureVault.Algorithms
{
    public class CaesarCipher : CipherBase
    {
        public override byte[] Encrypt(byte[] data, string key)
        {
            Validate(data);

            int shift = int.Parse(key);

            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] + shift);
            }

            return result;
        }

        public override byte[] Decrypt(byte[] data, string key)
        {
            Validate(data);

            int shift = int.Parse(key);

            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] - shift);
            }

            return result;
        }
    }
}