using SecureVault.Core;

namespace SecureVault.Algorithms
{
    public class VigenereCipher : CipherBase
    {
        public override byte[] Encrypt(byte[] data, string key)
        {
            Validate(data);
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] + key[i % key.Length]);
            }

            return result;
        }

        public override byte[] Decrypt(byte[] data, string key)
        {
            Validate(data);
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] - key[i % key.Length]);
            }

            return result;
        }
    }
}